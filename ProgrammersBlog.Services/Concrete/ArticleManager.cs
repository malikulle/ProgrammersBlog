using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<IResult> Add(ArticleAddDto articleDto, string createdName, int userId)
        {
            var article = _mapper.Map<Article>(articleDto);
            article.CreatedByName = createdName;
            article.ModifiedByName = createdName;
            article.UserId = userId;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleDto.Title} eklendi");
        }

        public async Task<IResult> Delete(int ArticleId, string modifiedName)
        {
            var result = await _unitOfWork.Articles.Any(x => x.Id == ArticleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == ArticleId);
                article.ModifiedByName = modifiedName;
                article.ModifiedDate = DateTime.Now;
                article.IsDeleted = true;
                article.IsActive = false;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} silindi");
            }
            return new Result(ResultStatus.Error, $"Makale bulunamadı");

        }

        public async Task<IResult> UndoDelete(int ArticleId, string modifiedName)
        {
            var result = await _unitOfWork.Articles.Any(x => x.Id == ArticleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == ArticleId);
                article.ModifiedByName = modifiedName;
                article.ModifiedDate = DateTime.Now;
                article.IsDeleted = false;
                article.IsActive = true;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} geri alındı.");
            }
            return new Result(ResultStatus.Error, $"Makale bulunamadı");
        }

        public async Task<IDataResult<ArticleDto>> Get(int ArticleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == ArticleId, x => x.User, x => x.Category);
            article.Comments = await _unitOfWork.Comments.GetAllAsync(x => x.ArticleId == article.Id && !x.IsDeleted && x.IsActive);

            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle Bir Makale Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, x => x.User, x => x.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => x.CategoryId == categoryId && x.IsActive && !x.IsDeleted, x => x.User, x => x.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, x => x.User, x => x.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => x.IsDeleted, x => x.User, x => x.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.User, x => x.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int ArticleId)
        {
            var result = await _unitOfWork.Articles.Any(x => x.Id == ArticleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == ArticleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{article.Title} silindi");
            }
            return new Result(ResultStatus.Error, $"Makale bulunamadı");
        }

        public async Task<IDataResult<int>> Count()
        {
            var count = await _unitOfWork.Articles.Count();

            return new DataResult<int>(ResultStatus.Success, count);
        }

        public async Task<IResult> Update(ArticleUpdateDto articleDto, string modifiedName)
        {
            var oldArticle = await _unitOfWork.Articles.GetAsync(x => x.Id == articleDto.Id);
            var article = _mapper.Map<ArticleUpdateDto, Article>(articleDto, oldArticle);
            article.ModifiedByName = modifiedName;
            article.ModifiedDate = DateTime.Now;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{articleDto.Title} güncellendi");

        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDto(int ArticleId)
        {
            var result = await _unitOfWork.Articles.Any(x => x.Id == ArticleId);

            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == ArticleId);
                var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, "Bulunamadı", null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByViewCount(bool IsAscdening, int? takeSize)
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => x.IsActive && !x.IsDeleted, x => x.Category, x => x.User);

            var sortedArticles = IsAscdening ? articles.OrderBy(x => x.ViewsCount) : articles.OrderByDescending(x => x.ViewsCount);

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto()
            {
                Articles = takeSize == null ? sortedArticles.ToList() : sortedArticles.Take(takeSize.Value).ToList()
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool IsAscdening = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await _unitOfWork.Articles.GetAllAsync(x => x.IsActive && !x.IsDeleted, x => x.Category, x => x.User)
                : await _unitOfWork.Articles.GetAllAsync(x => x.IsActive && !x.IsDeleted && x.CategoryId == categoryId, x => x.Category, x => x.User);

            var sortedArticles = IsAscdening
                ? articles.OrderBy(x => x.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = IsAscdening,
                ResultStatus = ResultStatus.Success,
            });
        }

        public async Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool IsAscdening = false)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await this.GetAllByPagingAsync(null, currentPage, pageSize, IsAscdening);
            }
            var articles = await _unitOfWork.Articles.SearchAsync(new List<Expression<Func<Article, bool>>>
            {
                (a) => a.Title.Contains(keyword),
                (a) => a.Category.Name.Contains(keyword),
                (a) => a.SeoDescription.Contains(keyword),
                (a) => a.SeoTags.Contains(keyword)
            }, a => a.Category, a => a.User);
            var sortedArticles = IsAscdening
                ? articles.OrderBy(x => x.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.Date).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = null,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = IsAscdening,
                ResultStatus = ResultStatus.Success,
            });
        }

        public async Task<IResult> IncreaseViewCountAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);

            if (article == null)
            {
                return new Result(ResultStatus.Error, "Article Not Found");
            }
            article.ViewsCount += 1;
            await _unitOfWork.Articles.UpdateAsync(article);
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy, bool isAsdening, int takeSize, int categoryId, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount, int maxCommentCount)
        {
            var anyUser = await _userManager.Users.AnyAsync(x => x.Id == userId);
            if (!anyUser)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Kullanıcı Bulunamadı", null);
            }
            var userArticles = await _unitOfWork.Articles.GetAllAsync(x => x.IsActive && !x.IsDeleted && x.UserId == userId);
            List<Article> sorteedArticle = new List<Article>();
            switch (filterBy)
            {
                case FilterBy.Category:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderBy(x => x.Date).ToList()
                                : userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderByDescending(x => x.Date).ToList();
                            break;
                        case OrderBy.ViewsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderBy(x => x.ViewsCount).ToList()
                                : userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderByDescending(x => x.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderBy(x => x.CommentsCount).ToList()
                                : userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderByDescending(x => x.CommentsCount).ToList();
                            break;
                        default:
                            sorteedArticle = isAsdening
                               ? userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderBy(x => x.Id).ToList()
                               : userArticles.Where(x => x.CategoryId == categoryId).Take(takeSize).OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                    break;
                case FilterBy.Date:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date).Take(takeSize).OrderBy(x => x.Date).ToList()
                                : userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date)
                                .Take(takeSize).OrderByDescending(x => x.Date).ToList();
                            break;
                        case OrderBy.ViewsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date).Take(takeSize).OrderBy(x => x.ViewsCount).ToList()
                                : userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date)
                                .Take(takeSize).OrderByDescending(x => x.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date).Take(takeSize).OrderBy(x => x.CommentsCount).ToList()
                                : userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date)
                                .Take(takeSize).OrderByDescending(x => x.CommentsCount).ToList();
                            break;
                        default:
                            sorteedArticle = isAsdening
                               ? userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date).Take(takeSize).OrderBy(x => x.Id).ToList()
                               : userArticles.Where(x => x.Date.Value.Date >= startAt.Date && x.Date.Value.Date <= endAt.Date)
                               .Take(takeSize).OrderByDescending(x => x.Id).ToList();
                            break;
                    }
                    break;
                case FilterBy.ViewsCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount).Take(takeSize).OrderBy(x => x.Date).ToList()
                                : userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                                .Take(takeSize).OrderByDescending(x => x.Date).ToList();
                            break;
                        case OrderBy.ViewsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                                .Take(takeSize).OrderBy(x => x.ViewsCount).ToList()
                                : userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                                .Take(takeSize).OrderByDescending(x => x.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                                .Take(takeSize).OrderBy(x => x.CommentsCount).ToList()
                                : userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                                .Take(takeSize).OrderByDescending(x => x.CommentsCount).ToList();
                            break;
                        default:
                            sorteedArticle = isAsdening
                               ? userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount).Take(takeSize).OrderBy(x => x.Id).ToList()
                               : userArticles.Where(x => x.ViewsCount.Value >= minViewCount && x.ViewsCount.Value <= maxViewCount)
                               .Take(takeSize).OrderByDescending(x => x.Id).ToList();
                            break;
                    }

                    break;
                case FilterBy.CommentsCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderBy(x => x.Date).ToList()
                                : userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderByDescending(x => x.Date).ToList();
                            break;
                        case OrderBy.ViewsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderBy(x => x.ViewsCount).ToList()
                                : userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderByDescending(x => x.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentsCount:
                            sorteedArticle = isAsdening
                                ? userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderBy(x => x.CommentsCount).ToList()
                                : userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                                .Take(takeSize).OrderByDescending(x => x.CommentsCount).ToList();
                            break;
                        default:
                            sorteedArticle = isAsdening
                               ? userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                               .Take(takeSize).OrderBy(x => x.Id).ToList()
                               : userArticles.Where(x => x.CommentsCount.Value >= minCommentCount && x.CommentsCount.Value <= maxCommentCount)
                               .Take(takeSize).OrderByDescending(x => x.Id).ToList();
                            break;
                    }

                    break;
                default:
                    break;
            }

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto() { Articles = sorteedArticle });
        }

        public async Task<IDataResult<ArticleDto>> GetById(int ArticleId, bool includeCategory, bool includeComments, bool includeUser)
        {
            var predicates = new List<Expression<Func<Article, bool>>>();
            var includes = new List<Expression<Func<Article, object>>>();
            if (includeCategory)
                includes.Add(x => x.Category);
            if (includeComments)
                includes.Add(x => x.Comments);
            if (includeUser)
                includes.Add(x => x.User);
            predicates.Add(x => x.Id == ArticleId);
            var article = await _unitOfWork.Articles.GetAsyncV2(predicates, includes);
            if (article == null)
                return new DataResult<ArticleDto>(ResultStatus.Warning, "Hata İle Karşılaşıldı", null);
            return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto()
            {
                Article = article
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllV2(int? categoryId, int? userId, bool? isActive, bool? isDeleted, int currentPage, int pageSize,OrderByGeneral orderBy, bool isAscreding, bool includeCategory, bool includeComments, bool includeUser)
        {
            var predicates = new List<Expression<Func<Article, bool>>>();
            var includes = new List<Expression<Func<Article, object>>>();
            if (includeCategory)
                includes.Add(x => x.Category);
            if (includeComments)
                includes.Add(x => x.Comments);
            if (includeUser)
                includes.Add(x => x.User);

            if (categoryId.HasValue)
                predicates.Add(x => x.CategoryId == categoryId);

            if (userId.HasValue)
                predicates.Add(x => x.UserId == userId);

            if (isActive.HasValue)
                predicates.Add(x => x.IsActive == isActive.Value);

            if (isDeleted.HasValue)
                predicates.Add(x => x.IsDeleted == isDeleted.Value);
            
            var articles = await _unitOfWork.Articles.GetAllAsyncV2(predicates, includes);

            IOrderedEnumerable<Article> sortedArticles;
            switch (orderBy)
            {
                case OrderByGeneral.Id:
                    sortedArticles = isAscreding ? articles.OrderBy(x => x.Id) : articles.OrderByDescending(x => x.Id);
                    break;
                case OrderByGeneral.Az:
                    sortedArticles = isAscreding ? articles.OrderBy(x => x.Title) : articles.OrderByDescending(x => x.Title);
                    break;
                default:
                    sortedArticles = isAscreding ? articles.OrderBy(x => x.CreatedDate) : articles.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto()
            {
                Articles = sortedArticles.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList(),
                CategoryId = categoryId,
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscreding,
                TotalCount = articles.Count,
                ResultStatus = ResultStatus.Success
            });

        }
    }
}

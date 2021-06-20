using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using ProgrammersBlog.Services.Messages;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CommentDto>> GetAsync(int commentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId)
        {
            var result = await _unitOfWork.Comments.Any(c => c.Id == commentId);
            if (result)
            {
                var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId);
                var commentUpdateDto = _mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, commentUpdateDto);
            }
            else
            {
                return new DataResult<CommentUpdateDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<CommentListDto>> GetAllAsync()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(null, x => x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByDeletedAsync()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(c => c.IsDeleted, x => x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAsync()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(c => !c.IsDeleted, x => x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(c => !c.IsDeleted && c.IsActive, x => x.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == commentAddDto.ArticleId);
            if (article == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error, "Article Not Found", null);
            }
            var comment = _mapper.Map<Comment>(commentAddDto);
            var addedComment = await _unitOfWork.Comments.AddAsync(comment);
            article.CommentsCount += 1;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.Messages.Comment.Add(commentAddDto.CreatedByName), new CommentDto
            {
                Comment = addedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == commentUpdateDto.ArticleId);
            if (article == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error, "Article Not Found", null);
            }
            var oldComment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentUpdateDto.Id, x => x.Article);
            var comment = _mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
            comment.ModifiedByName = modifiedByName;
            var updatedComment = await _unitOfWork.Comments.UpdateAsync(comment);
            updatedComment.Article = await _unitOfWork.Articles.GetAsync(x => x.Id == updatedComment.ArticleId);
            article.CommentsCount = await _unitOfWork.Comments.Count(x => x.ArticleId == article.Id && !x.IsDeleted);
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.Messages.Comment.Update(comment.CreatedByName), new CommentDto
            {
                Comment = updatedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> DeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId, x => x.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsDeleted = true;
                comment.IsActive = false;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await _unitOfWork.Comments.UpdateAsync(comment);
                article.CommentsCount -= 1;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Messages.Comment.UndoDelete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IDataResult<CommentDto>> UndoDeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId, x => x.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsDeleted = false;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDate = DateTime.Now;
                var deletedComment = await _unitOfWork.Comments.UpdateAsync(comment);
                article.CommentsCount += 1;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Messages.Comment.Delete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IResult> HardDeleteAsync(int commentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId,x=> x.Article);
            if (comment != null)
            {
                if (comment.IsDeleted)
                {
                    await _unitOfWork.Comments.DeleteAsync(comment);
                    await _unitOfWork.SaveAsync();
                    return new Result(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false));

                }
                var article = comment.Article;
                article.CommentsCount = await _unitOfWork.Comments.Count(x => x.ArticleId == article.Id && !x.IsDeleted);
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Messages.Comment.HardDelete(comment.CreatedByName));
            }
            return new Result(ResultStatus.Error, Messages.Messages.Comment.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> Count()
        {
            var count = await _unitOfWork.Comments.Count();

            return new DataResult<int>(ResultStatus.Success, count);
        }

        public async Task<IDataResult<int>> CountByIsDeleted()
        {
            var count = await _unitOfWork.Comments.Count(x => !x.IsDeleted);

            return new DataResult<int>(ResultStatus.Success, count);
        }

        public async Task<IDataResult<CommentDto>> ApproveAsync(int commentId, string modifedByName)
        {
            var comment = await _unitOfWork.Comments.GetAsync(x => x.Id == commentId, x => x.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsActive = true;
                comment.ModifiedByName = modifedByName;
                comment.ModifiedDate = DateTime.Now;
                article.CommentsCount = await _unitOfWork.Comments.Count(x => x.ArticleId == article.Id && !x.IsDeleted);
                var updatedComment = await _unitOfWork.Comments.UpdateAsync(comment);
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();

                return new DataResult<CommentDto>(ResultStatus.Success, "Yorum Onaylandı.", new CommentDto { Comment = updatedComment });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, "Bir hata olustu...", null);
        }
    }
}

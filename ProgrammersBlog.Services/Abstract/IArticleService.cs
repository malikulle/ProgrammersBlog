using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int ArticleId);
        Task<IDataResult<ArticleDto>> GetById(int ArticleId, bool includeCategory, bool includeComments, bool includeUser);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDto(int ArticleId);
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByViewCount(bool IsAscdening, int? takeSize);
        Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool IsAscdening = false);
        Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter(int userId, FilterBy filterBy, OrderBy orderBy, bool isAsdening, int takeSize, int categoryId, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommentCount, int maxCommentCount);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllV2(int? categoryId, int? userId, bool? isActive, bool? isDeleted,int currentPage, int pageSize,OrderByGeneral orderBy,bool isAscreding, bool includeCategory, bool includeComments, bool includeUser);
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ArticleAddDto articleDto, string createdName, int userId);
        Task<IResult> Update(ArticleUpdateDto articleDto, string modifiedName);
        Task<IResult> Delete(int ArticleId, string modifiedName);
        Task<IResult> UndoDelete(int ArticleId, string modifiedName);
        Task<IResult> HardDelete(int ArticleId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool IsAscdening = false);
        Task<IResult> IncreaseViewCountAsync(int articleId);
    }
}

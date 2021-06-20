using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int CategoryId);

        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int CategoryId);

        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<CategoryListDto>> GetAll();

        Task<IDataResult<CategoryDto>> Add(CategoryAddDto category, string createdName);

        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto category, string modifiedName);

        Task<IDataResult<CategoryDto>> Delete(int CategoryId, string modifiedName);
        Task<IDataResult<CategoryDto>> UndoDelete(int CategoryId, string modifiedName);
        Task<IResult> HardDelete(int CategoryId);

        Task<IDataResult<int>> Count();
    }
}

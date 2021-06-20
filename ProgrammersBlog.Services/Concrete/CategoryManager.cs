using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto category, string createdName)
        {
            //var newCategory = new Category()
            //{
            //    Name = category.Name,
            //    Note = category.Note,
            //    Description = category.Description,
            //    IsActive = category.IsActive
            //};
            var newCategory = _mapper.Map<Category>(category);
            newCategory.CreatedByName = createdName;
            newCategory.ModifiedByName = createdName;

            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.SaveAsync();

            return new DataResult<CategoryDto>(ResultStatus.Success, "Kategori eklenmiştir", new CategoryDto { Category = newCategory, ResultStatus = ResultStatus.Success, Message = "Kategori Eklenmiştir" });
        }

        public async Task<IDataResult<CategoryDto>> Delete(int CategoryId, string modifiedName)
        {

            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == CategoryId);

            if (category != null)
            {
                category.IsDeleted = true;
                category.IsActive = false;
                category.ModifiedByName = modifiedName;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, "Category Deleteed", data: new CategoryDto { Message = "Category Deleteed", ResultStatus = ResultStatus.Success, Category = category });
            }

            return new DataResult<CategoryDto>(ResultStatus.Error, "Not Deleted", new CategoryDto { Category = null, ResultStatus = ResultStatus.Error, Message = "Kategori Bulunamadı" });
        }

        public async Task<IDataResult<CategoryDto>> UndoDelete(int CategoryId, string modifiedName)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == CategoryId);

            if (category != null)
            {
                category.IsDeleted = false;
                category.IsActive = true;
                category.ModifiedByName = modifiedName;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, "Category Deleteed", data: new CategoryDto { Message = "Category Undo Deleteed", ResultStatus = ResultStatus.Success, Category = category });
            }

            return new DataResult<CategoryDto>(ResultStatus.Error, "Not Deleted", new CategoryDto { Category = null, ResultStatus = ResultStatus.Error, Message = "Kategori Bulunamadı" });
        }

        public async Task<IDataResult<CategoryDto>> Get(int CategoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == CategoryId, x => x.Articles);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto { Category = category, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Not Found", null);

        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int CategoryId)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == CategoryId, x => x.Articles);
                if (category != null)
                {
                    var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
                    return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
                }
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, "Not Found", null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {

            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Not Found", new CategoryListDto { ResultStatus = ResultStatus.Error, Categories = null, Message = "Hiç Bir Kategori bulunamadı" });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x=> !x.IsDeleted, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Not Found", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => x.IsDeleted, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Not Found", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto { Categories = categories, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Not Found", null);
        }

        public async Task<IResult> HardDelete(int CategoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == CategoryId);

            if (category != null)
            {

                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, "Deleted");

            }

            return new Result(ResultStatus.Error, "Not Deleted");
        }

        public async Task<IDataResult<int>> Count()
        {
            var categoriesCount = await _unitOfWork.Categories.Count();

            return new DataResult<int>(ResultStatus.Success,categoriesCount);
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto category, string modifiedName)
        {
            var categoryInDb = await _unitOfWork.Categories.GetAsync(x => x.Id == category.Id);

            if (categoryInDb != null)
            {
                categoryInDb.Name = category.Name;
                categoryInDb.Description = category.Description;
                categoryInDb.Note = category.Note;
                categoryInDb.IsActive = category.IsActive;
                categoryInDb.IsDeleted = category.IsDelete;
                categoryInDb.ModifiedByName = modifiedName;
                categoryInDb.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(categoryInDb);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, "Updated", data: new CategoryDto { Message = "Updated", ResultStatus = ResultStatus.Success, Category = categoryInDb });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Not Updated", new CategoryDto { Category = null, ResultStatus = ResultStatus.Error, Message = "Kategori Bulunamadı" });

        }
    }
}

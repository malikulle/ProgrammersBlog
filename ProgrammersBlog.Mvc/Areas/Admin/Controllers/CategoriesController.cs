using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;
using ProgrammersBlog.WebMvc.Helpers.Abstract;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper ımageHelper) : base(userManager, mapper, ımageHelper)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllByNonDeleted();

            return View(result.Data);
        }

        [Authorize(Roles = "SuperAdmin,Category.Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }

        [Authorize(Roles = "SuperAdmin,Category.Add")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, LoggedInUser.UserName);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel()
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto),
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel()
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto),
            });
            return Json(categoryAddAjaxErrorModel);
        }

        [Authorize(Roles = "SuperAdmin,Category.Get")]
        [HttpGet]
        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAll();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }

        [Authorize(Roles = "SuperAdmin,Category.Delete")]
        [HttpDelete]
        public async Task<JsonResult> DeleteCategories(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId, LoggedInUser.UserName);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }

        [Authorize(Roles = "SuperAdmin,Category.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var result = await _categoryService.GetCategoryUpdateDto(categoryId);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "SuperAdmin,Category.Update")]        
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(categoryUpdateDto, LoggedInUser.UserName);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryUpdatejaxViewModel()
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto),
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryUpdatejaxViewModel()
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto),
            });
            return Json(categoryAddAjaxErrorModel);
        }

        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedCategories()
        {
            var result = await _categoryService.GetAllByDeleted();
            return View(result.Data);
        }

        [Authorize(Roles = "SuperAdmin,Category.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedCategories()
        {
            var result = await _categoryService.GetAllByDeleted();
            var categories = JsonSerializer.Serialize(result.Data,
                new JsonSerializerOptions() {ReferenceHandler = ReferenceHandler.Preserve});
            return Json(categories);
        }

        [Authorize(Roles = "SuperAdmin,Category.Update")]
        [HttpDelete]
        public async Task<JsonResult> UndoDelete(int categoryId)
        {
            var result = await _categoryService.UndoDelete(categoryId, LoggedInUser.UserName);
            var ajaxResult = JsonSerializer.Serialize(result.Data);
            return Json(ajaxResult);
        }

        [Authorize(Roles = "SuperAdmin,Category.Delete")]
        [HttpDelete]
        public async Task<JsonResult> HardDelete(int categoryId)
        {
            var result = await _categoryService.HardDelete(categoryId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
    }
}

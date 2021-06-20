using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.WebMvc.Helpers.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using ProgrammersBlog.Entities.Concrete;
using System.Text.Json.Serialization;
using NToastNotify;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ArticleController(UserManager<User> userManager, IArticleService articleService, ICategoryService categoryService, IMapper mapper, IImageHelper ımageHelper, IToastNotification toastNotification)
            : base(userManager, mapper, ımageHelper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        [Authorize(Roles = "SuperAdmin, Article.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllByNonDeletedAndActive();

            return View(articles.Data);
        }

        [Authorize(Roles = "SuperAdmin, Article.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllByNonDeleted();
            var model = new ArticleAddViewModel()
            {
                Categories = categories.Data.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
            return View(model);
        }

        [Authorize(Roles = "SuperAdmin, Article.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllByNonDeleted();
                model.Categories = categories.Data.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
                return View(model);
            }
            try
            {
                var articleAddDto = Mapper.Map<ArticleAddDto>(model);

                var imageResult = await ImageHelper.Upload(model.Title, model.ThumbnailFile, PictureType.Post);
                articleAddDto.Thumbnail = imageResult.Data.FullName;

                var result = await _articleService.Add(articleAddDto, LoggedInUser.UserName, LoggedInUser.Id);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    _toastNotification.AddSuccessToastMessage("Başarılı Bir Şekilde Eklenmiştir.");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

            }
            TempData.Add("ErrorMessage", "Bir Hata Oluştu. Tekrar Deneyiniz.");
            return View(model);
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int articleId)
        {
            var articleResult = await _articleService.GetArticleUpdateDto(articleId);
            var categories = await _categoryService.GetAllByNonDeleted();

            if (articleResult.ResultStatus == ResultStatus.Success)
            {
                var articleUpdateViewModel = Mapper.Map<ArticleUpdateViewModel>(articleResult.Data);
                articleUpdateViewModel.Categories = categories.Data.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                return View(articleUpdateViewModel);
            }

            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllByNonDeleted();
                model.Categories = categories.Data.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
                return View(model);
            }

            bool isNewThumbnailUploded = false;
            string oldThumbnail = model.Thumbnail;


            if (model.ThumbnailFile != null)
            {
                var uplodedImageResult = await ImageHelper.Upload(model.Title, model.ThumbnailFile, PictureType.Post);
                if (uplodedImageResult.ResultStatus == ResultStatus.Success)
                {
                    isNewThumbnailUploded = true;
                    model.Thumbnail = uplodedImageResult.Data.FullName;
                }
                else
                {
                    model.Thumbnail = "postImages/defaultThumbnail.jpg";
                }
            }

            var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(model);
            var result = await _articleService.Update(articleUpdateDto, LoggedInUser.UserName);

            if (result.ResultStatus == ResultStatus.Success)
            {
                if (isNewThumbnailUploded)
                {
                    ImageHelper.Delete(oldThumbnail);
                }

                _toastNotification.AddSuccessToastMessage("Başarılı Bir Şekilde Güncellenmiştir.");
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int articleId)
        {
            var result = await _articleService.Delete(articleId, LoggedInUser.UserName);

            var articleResult = JsonSerializer.Serialize(result);

            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllByNonDeletedAndActive();
            var articleResult = JsonSerializer.Serialize(articles, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedArticles()
        {
            var result = await _articleService.GetAllByDeleted();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedArticles()
        {
            var result = await _articleService.GetAllByDeleted();
            var articles = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articles);
        }
        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int articleId)
        {
            var result = await _articleService.UndoDelete(articleId, LoggedInUser.UserName);
            var undoDeleteArticleResult = JsonSerializer.Serialize(result);
            return Json(undoDeleteArticleResult);
        }
        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int articleId)
        {
            var result = await _articleService.HardDelete(articleId);
            var hardDeletedArticleResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedArticleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllByViewCount(bool isAsceding,int takeSize)
        {
            var articles = await _articleService.GetAllByViewCount(isAsceding,takeSize);
            var articleResult = JsonSerializer.Serialize(articles.Data.Articles, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
            return Json(articleResult);
        }

    }
}

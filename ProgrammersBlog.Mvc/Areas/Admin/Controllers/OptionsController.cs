using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;
using ProgrammersBlog.Shared.Helpers.Abstract;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using AutoMapper;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]
    public class OptionsController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly WebSiteInfo _webSiteInfo;
        private readonly SmtpSettings _smtpSettings;
        private readonly ArticleRightSideBarWidgetOptions _articleRightSideBarWidgetOptions;      
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsInfoWriter;
        private readonly IWritableOptions<WebSiteInfo> _webSiteInfoWriter;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;
        private readonly IWritableOptions<ArticleRightSideBarWidgetOptions> _articleWriteSideBarWidgetOptionsWriter;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;
        public OptionsController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IWritableOptions<AboutUsPageInfo> aboutUsInfoWriter, IToastNotification toastNotification, IOptionsSnapshot<WebSiteInfo> webSiteInfo, IWritableOptions<WebSiteInfo> webSiteInfoWriter, IOptionsSnapshot<SmtpSettings> smtpSettings, IWritableOptions<SmtpSettings> smtpSettingsWriter,IOptionsSnapshot<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptions, IWritableOptions<ArticleRightSideBarWidgetOptions> articleWriteSideBarWidgetOptionsWriter,ICategoryService categoryService, IMapper mapper)
        {
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _webSiteInfo = webSiteInfo.Value;
            _smtpSettings = smtpSettings.Value;
            _articleRightSideBarWidgetOptions = articleRightSideBarWidgetOptions.Value;
            _aboutUsInfoWriter = aboutUsInfoWriter;
            _toastNotification = toastNotification;
            _webSiteInfoWriter = webSiteInfoWriter;
            _smtpSettingsWriter = smtpSettingsWriter;
            _articleWriteSideBarWidgetOptionsWriter = articleWriteSideBarWidgetOptionsWriter;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }

        [HttpPost]
        public IActionResult About(AboutUsPageInfo model)
        {
            if (ModelState.IsValid)
            {
                _aboutUsInfoWriter.Update(x =>
                {
                    x.Header = model.Header;
                    x.Content = model.Content;
                    x.SeoAuthor = model.SeoAuthor;
                    x.SeoDescription = model.SeoDescription;
                    x.SeoTags = model.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Hakkımızda Sayfa İçerikleri Başarılı Bir Şekilde Güncellenmiştir.", new ToastrOptions(){Title = "Başarılı İşlem"});
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_webSiteInfo);
        }

        [HttpPost]
        public IActionResult GeneralSettings(WebSiteInfo model)
        {
            if (ModelState.IsValid)
            {
                _webSiteInfoWriter.Update(x =>
                {
                    x.Title = model.Title;
                    x.MenuTitle = model.MenuTitle;
                    x.SeoAuthor = model.SeoAuthor;
                    x.SeoDescription = model.SeoDescription;
                    x.SeoTags = model.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Genel Ayarlar Başarılı Bir Şekilde Güncellenmiştir.", new ToastrOptions() { Title = "Başarılı İşlem" });
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }

        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings model)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = model.Server;
                    x.Port = model.Port;
                    x.SenderName = model.SenderName;
                    x.SenderEmail = model.SenderEmail;
                    x.Username = model.Username;
                    x.Password = model.Password;
                });
                _toastNotification.AddSuccessToastMessage("EPosta Ayarları Başarılı Bir Şekilde Güncellenmiştir.", new ToastrOptions() { Title = "Başarılı İşlem" });
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActive();
            var viewModel = _mapper.Map<ArticleRightSideBarWidgetOptionsViewModel>(_articleRightSideBarWidgetOptions);
            viewModel.Categories = categoriesResult.Data.Categories;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings(ArticleRightSideBarWidgetOptionsViewModel model)
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActive();
            model.Categories = categoriesResult.Data.Categories;
            if (ModelState.IsValid)
            {
                _articleWriteSideBarWidgetOptionsWriter.Update(x =>
                {
                    x.Header = model.Header;
                    x.TakeSize = model.TakeSize;
                    x.CategoryId = model.CategoryId;
                    x.FilterBy = model.FilterBy;
                    x.OrderBy = model.OrderBy;
                    x.IsAscending = model.IsAscending;
                    x.StartAt = model.StartAt;
                    x.EndAt = model.EndAt;
                    x.MaxViewCount = model.MaxViewCount;
                    x.MinViewCount = model.MinViewCount;
                    x.MaxCommentCount = model.MaxCommentCount;
                    x.MinCommentCount = model.MinCommentCount;
                });
                _toastNotification.AddSuccessToastMessage("Widget Güncelleme Bir Şekilde Güncellenmiştir.", new ToastrOptions() { Title = "Başarılı İşlem" });

            }
            return View(model);
        }

    }
}

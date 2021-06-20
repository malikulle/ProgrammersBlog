using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsInfoWriter;

        public HomeController(IArticleService articleService,IOptionsSnapshot<AboutUsPageInfo> aboutUsePageInfo, IMailService mailService, IToastNotification toastNotification, IWritableOptions<AboutUsPageInfo> aboutUsInfoWriter)
        {
            _articleService = articleService;
            _aboutUsPageInfo = aboutUsePageInfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _aboutUsInfoWriter = aboutUsInfoWriter;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 3,bool isAscending=false)
        {
            var articleDto = await _articleService.GetAllByPagingAsync(categoryId,currentPage,pageSize, isAscending);
            return View(articleDto.Data);
        }

        [HttpGet]
        public IActionResult About()
        {
            //_aboutUsInfoWriter.Update(x => 
            //{
            //    x.Header = "Yeni Başlık";
            //    x.Content = "Yeni İçerik";
            //});
            return View(_aboutUsPageInfo);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(EmailSendDto Model)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(Model);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View();
            }

            return View(Model);
        }
    }
}

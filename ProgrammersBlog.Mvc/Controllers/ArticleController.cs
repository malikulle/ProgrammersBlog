using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Helpers.Abstract;
using ProgrammersBlog.WebMvc.Attributes;
using ProgrammersBlog.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Controllers
{
    public class ArticleController : Controller
    {

        private readonly IArticleService _articleService;
        private readonly ArticleRightSideBarWidgetOptions _articleRightSideBarWidgetOptions;
        public ArticleController(IArticleService articleService, IOptionsSnapshot<ArticleRightSideBarWidgetOptions> articleWriteSideBarWidgetOptionsWriter)
        {
            _articleService = articleService;
            _articleRightSideBarWidgetOptions = articleWriteSideBarWidgetOptionsWriter.Value;
        }

        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var searchResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);

            if (searchResult.ResultStatus == Shared.Utilities.Results.ComplexTypes.ResultStatus.Success)
            {
                return View(new ArticleSearchViewModel()
                {
                    ArticleListDto = searchResult.Data,
                    Keyword = keyword
                });
            }
            return NotFound();
        }

        [HttpGet]
        [ViewCountFilter]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _articleService.Get(articleId);
            var userArticles = await _articleService.GetAllByUserIdOnFilter((int)articleResult.Data.Article.UserId, _articleRightSideBarWidgetOptions.FilterBy, _articleRightSideBarWidgetOptions.OrderBy, _articleRightSideBarWidgetOptions.IsAscending, _articleRightSideBarWidgetOptions.TakeSize, (int)_articleRightSideBarWidgetOptions.CategoryId, _articleRightSideBarWidgetOptions.StartAt,_articleRightSideBarWidgetOptions.EndAt, _articleRightSideBarWidgetOptions.MinViewCount, _articleRightSideBarWidgetOptions.MaxViewCount, _articleRightSideBarWidgetOptions.MinCommentCount, _articleRightSideBarWidgetOptions.MaxCommentCount);
            //await _articleService.IncreaseViewCountAsync(articleId);
            return View(new ArticleDetailViewModel()
            {
                ArticleDto = articleResult.Data,
                ArticleRightSidebarViewModel = new ArticleRightSidebarViewModel()
                {
                    ArticleListDto = userArticles.Data,
                    Header = _articleRightSideBarWidgetOptions.Header,
                    User = articleResult.Data.Article.User
                }
            });
        }
    }
}

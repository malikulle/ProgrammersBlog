using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.ViewComponents
{
    public class RightSideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;

        public RightSideBarViewComponent(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryResult = await _categoryService.GetAllByNonDeletedAndActive();
            var articleResult = await _articleService.GetAllByViewCount(IsAscdening: false, takeSize: 5);
            return View(new RightSideBarViewModel()
            {
                Articles = articleResult.Data.Articles,
                Categories = categoryResult.Data.Categories
            });
        }
    }
}

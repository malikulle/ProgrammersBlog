using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        public HomeController(ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var categoroiesCount = await _categoryService.Count();
            var articlesCount = await _articleService.Count();
            var commentsCount = await _commentService.Count();
            var userCount = await _userManager.Users.CountAsync();
            var articles = await _articleService.GetAll();

            var model = new DashboardViewModel()
            {
                CategoriesCount = categoroiesCount.Data,
                ArticlesCount = articlesCount.Data,
                CommentsCount = commentsCount.Data,
                UsersCount = userCount,
                Articles = articles.Data
            };
            return View(model);
        }
    }
}

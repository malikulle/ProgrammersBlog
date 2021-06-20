using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.WebMvc.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {

        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper, IImageHelper ımageHelper) : base(userManager, mapper, ımageHelper)
        {
            _roleManager = roleManager;
        }

        [Authorize(Roles = "SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var model = new RoleListDto
            {
                Roles = roles
            };

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var model = new RoleListDto
            {
                Roles = roles
            };

            var result = JsonSerializer.Serialize(model);

            return Json(result);
        }
        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<IActionResult> Assign(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(x => x.Id == userId);

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await UserManager.GetRolesAsync(user);

            var userRoleAssignDto = new UserRoleAssignDto
            {
                UserId = user.Id,
                Username = user.UserName,
                RoleAssignDtos = roles.Select(x => new RoleAssignDto
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    HasRole = userRoles.Contains(x.Name)
                }).ToList()
            };
            return PartialView("_RoleAssignPartial", userRoleAssignDto);
        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleAssignDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.Users.SingleOrDefaultAsync(x => x.Id == model.UserId);

                foreach (var roleAssignDto in model.RoleAssignDtos)
                {
                    if (roleAssignDto.HasRole)
                        await UserManager.AddToRoleAsync(user, roleAssignDto.RoleName);

                    else
                        await UserManager.RemoveFromRoleAsync(user, roleAssignDto.RoleName);

                }

                await UserManager.UpdateSecurityStampAsync(user);
                var userRoleAssignAjaxViewModel = JsonSerializer.Serialize(new UserRoleAsignAjaxViewModel()
                {
                    UserDto = new UserDto() { User = user, Message = $"{user.UserName} kullanıcısına air role atama işlemi tamamlandı.", ResultStatus = ResultStatus.Success },
                    RoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssignPartial",model)
                });

                return Json(userRoleAssignAjaxViewModel);
            }
            else
            {
                var userRoleAssignErrorModel = JsonSerializer.Serialize(new UserRoleAsignAjaxViewModel()
                {
                    RoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssignPartial", model),
                    UserRoleAssignDto = model
                });
                return Json(userRoleAssignErrorModel);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.WebMvc.Areas.Admin.Models;
using ProgrammersBlog.WebMvc.Helpers.Abstract;
using ProgrammersBlog.Entities.ComplexTypes;

namespace ProgrammersBlog.WebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IImageHelper _imageHelper;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env, IMapper mapper, SignInManager<User> signInManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _env = env;
            _mapper = mapper;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
        }
        [Authorize(Roles = "SuperAdmin,User.Read")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(new UserListDto()
            {
                Users = users,
                Message = "Kullanıclar Bulundu",
                ResultStatus = ResultStatus.Success
            });
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin,User.Read")]
        public async Task<PartialViewResult> GetDetail(int userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return PartialView("_GetDetailPartial", new UserDto { User = user });
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,User.Read")]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = JsonSerializer.Serialize(new UserListDto()
            {
                Users = users,
                Message = "Kullanıclar Bulundu",
                ResultStatus = ResultStatus.Success
            }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });

            return Json(result);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,User.Create")]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,User.Create")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (!ModelState.IsValid)
            {
                var userAddAjaxNotValidModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                {
                    UserAddPartialView = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                });
                return Json(userAddAjaxNotValidModel);
            }

            var uploadedImage = await _imageHelper.Upload(userAddDto.UserName, userAddDto.PictureFile, PictureType.User);
            userAddDto.Picture = uploadedImage.ResultStatus == ResultStatus.Success ? uploadedImage.Data.FullName : "/userImages/defaultUser.png";
            string password = userAddDto.Password;
            var user = _mapper.Map<User>(userAddDto);

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var UserAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                {
                    UserAddDto = userAddDto,
                    UserAddPartialView = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto),
                    UserDto = new UserDto()
                    {
                        ResultStatus = ResultStatus.Success,
                        Message = "Kullanıcı Eklendi",
                        User = user
                    }
                });
                return Json(UserAddAjaxModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel()
                {
                    UserAddDto = userAddDto,
                    UserAddPartialView = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                });
                return Json(userAddAjaxErrorModel);
            }


        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,User.Delete")]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var picture = user.Picture;

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                var deletedUser = JsonSerializer.Serialize(new UserDto()
                {
                    ResultStatus = ResultStatus.Success,
                    Message = "Kullanıcı Silindi",
                    User = user
                });
                if (picture != "/userImages/defaultUser.png")
                {
                    _imageHelper.Delete(picture);
                }
                return Json(deletedUser);
            }
            else
            {
                string errorMessages = String.Empty;

                foreach (var error in result.Errors)
                {
                    errorMessages += $"{error.Description}\n";
                }

                var deletedUserErr = JsonSerializer.Serialize(new UserDto()
                {
                    ResultStatus = ResultStatus.Error,
                    Message = errorMessages
                });

                return Json(deletedUserErr);
            }
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,User.Update")]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);

            return PartialView("_UserUpdatePartial", userUpdateDto);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,User.Update")]
        public async Task<IActionResult> Update(UserUpdateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNewPictureUploaded = false;
                    var oldUser = await _userManager.FindByIdAsync(model.Id.ToString());
                    var oldUserPictrue = oldUser.Picture;

                    if (model.PictureFile != null)
                    {
                        var uploadedImage = await _imageHelper.Upload(model.UserName, model.PictureFile, PictureType.User);
                        model.Picture = uploadedImage.ResultStatus == ResultStatus.Success ? uploadedImage.Data.FullName : "userImages/defaultUser.png";
                        if (oldUserPictrue != "userImages/defaultUser.png")
                        {
                            isNewPictureUploaded = true;
                        }
                    }

                    var updatedUser = _mapper.Map<User>(model);

                    var userInDb = await _userManager.FindByIdAsync(model.Id.ToString());

                    userInDb.UserName = model.UserName;
                    userInDb.Email = model.Email;
                    userInDb.PhoneNumber = model.PhoneNumber;
                    userInDb.Picture = model.Picture;


                    var result = await _userManager.UpdateAsync(userInDb);

                    if (result.Succeeded)
                    {
                        if (isNewPictureUploaded)
                        {
                            _imageHelper.Delete(oldUserPictrue);
                        }

                        var userUpdateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                        {
                            UserDto = new UserDto()
                            {
                                ResultStatus = ResultStatus.Success,
                                User = updatedUser,
                                Message = "Kullanıcı Güncellendi."
                            },
                            UserUpdatePartialView = await this.RenderViewToStringAsync("_UserUpdatePartial", model)
                        });
                        return Json(userUpdateViewModel);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                        {
                            UserUpdateDto = model,
                            UserUpdatePartialView = await this.RenderViewToStringAsync("_UserUpdatePartial", model)
                        });
                        return Json(userUpdateErrorViewModel);
                    }
                }
                else
                {
                    var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel()
                    {
                        UserUpdateDto = model,
                        UserUpdatePartialView = await this.RenderViewToStringAsync("_UserUpdatePartial", model)
                    });
                    return Json(userUpdateErrorViewModel);
                }
            }
            catch (Exception e)
            {
                return Json(null);
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<ViewResult> ChangeDetails()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var updateDto = _mapper.Map<UserUpdateDto>(user);

            return View(updateDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ViewResult> ChangeDetails(UserUpdateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNewPictureUploaded = false;
                    var oldUser = await _userManager.GetUserAsync(HttpContext.User);
                    var oldUserPictrue = oldUser.Picture;

                    if (model.PictureFile != null)
                    {
                        var uploadedImage = await _imageHelper.Upload(model.UserName, model.PictureFile, PictureType.User);
                        model.Picture = uploadedImage.ResultStatus == ResultStatus.Success ? uploadedImage.Data.FullName : "userImages/defaultUser.png";
                        if (oldUserPictrue != "userImages/defaultUser.png")
                        {
                            isNewPictureUploaded = true;
                        }
                    }

                    var updatedUser = _mapper.Map<User>(model);

                    var userInDb = await _userManager.FindByIdAsync(model.Id.ToString());

                    userInDb.UserName = model.UserName;
                    userInDb.Email = model.Email;
                    userInDb.PhoneNumber = model.PhoneNumber;
                    userInDb.Picture = model.Picture;


                    var result = await _userManager.UpdateAsync(userInDb);

                    if (result.Succeeded)
                    {
                        if (isNewPictureUploaded)
                        {
                            _imageHelper.Delete(oldUserPictrue);
                        }
                        TempData.Add("SuccessMessage", "Kullanıcı Güncellenmiştir.");
                        return View(model);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public ViewResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ViewResult> PasswordChange(UserPasswordChangeDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var isVerified = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);

                if (isVerified)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, model.NewPassword, true, false);
                        TempData.Add("SuccessMessage", "Şifreniz Başarılı Bir Şekilde Değiştirilmiştir.");
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                            return View(model);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen Şifrenizi Kontrol Ediniz.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

            return View();

        }
    }
}

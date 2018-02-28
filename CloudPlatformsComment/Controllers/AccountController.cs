using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudPlatformsComment.Models;
using CloudPlatformsComment.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlatformsComment.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                var identityUser = new ApplicationUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    NormalizedUserName = registerViewModel.Email,
                };

                var identityResult = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (identityResult.Succeeded)
                {
                    await _signinManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });
                    return RedirectToLoacl(returnUrl);
                }
                else
                {
                    AddErrors(identityResult);
                }
            }

            return View();
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = returnUrl;
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError(nameof(loginViewModel.Email), "该账户不存在！");
                }
                else
                {
                    var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginViewModel.Password);
                    
                    if (result == PasswordVerificationResult.Success)
                    {
                        await _signinManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = true });
                        return RedirectToLoacl(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(loginViewModel.Password), "邮箱或密码错误！");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
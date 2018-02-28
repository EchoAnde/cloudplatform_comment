using CloudPlatformsComment.IServices;
using CloudPlatformsComment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<ApplicationUser> _userManager;
        protected SignInManager<ApplicationUser> _signinManager;
        protected ICommentService _commentService;
        protected ICloudPlatformService _cloudPlatformService; 

        /// <summary>
        /// 跳转本地链接
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        protected IActionResult RedirectToLoacl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

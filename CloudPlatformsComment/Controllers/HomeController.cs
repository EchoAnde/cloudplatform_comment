using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudPlatformsComment.Models;
using Microsoft.AspNetCore.Authorization;
using CloudPlatformsComment.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CloudPlatformsComment.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICloudPlatformService cloudPlatformService, ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _commentService = commentService;
            _cloudPlatformService = cloudPlatformService;
        }

        // GET：主页云服务商列表
        public IActionResult Index()
        {
            // 获取云服务商列表
            var platforms = _cloudPlatformService.GetAllCloudPlatformList();
            return View(platforms);
        }

        // GET：错误信息
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

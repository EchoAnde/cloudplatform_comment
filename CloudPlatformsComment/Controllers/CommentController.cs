﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudPlatformsComment.IServices;
using CloudPlatformsComment.Models;
using CloudPlatformsComment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlatformsComment.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ICommentService commentService, ICloudPlatformService cloudPlatformService, UserManager<ApplicationUser> userManager, ICloudProductService cloudProductService)
        {
            _userManager = userManager;
            _commentService = commentService;
            _cloudPlatformService = cloudPlatformService;
            _cloudProductService = cloudProductService;
        }

        // GET：评论列表
        public IActionResult List(int? id)
        {
            if (id.HasValue)
            {
                // 获取云产品
                var product = _cloudProductService.FindById(id.Value);
                // 是否存在
                if (product != null)
                {
                    var viewmodel = new CommentListViewModel
                    {
                        ProductName = product.ProductName,
                        Description = product.ProductDesc,
                        Image = product.Image,
                        ProductId = product.Id,
                        PlatformId = product.CloudPlatform.Id,
                        PlatformName = product.CloudPlatform.PlatformName
                    };
                    // 对评论列表分页 默认 第1页 每页10条记录
                    viewmodel.Comments = GetCommentList(1, 10, out var total, id.Value);
                    viewmodel.TotalCount = total;
                    return View(viewmodel);
                }
            }
            return NotFound();
        }

        public IActionResult GetList(int platformId, int pageIndex = 1)
        {
            var comments = GetCommentList(pageIndex, 10, out var total, platformId);
            if (comments != null && comments.Count > 0)
            {
                return Json(new { success = true, data = comments, pageIndex = pageIndex + 1 });
            }
            return Json(new { success = false, data = comments, pageIndex });
        }

        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">行数</param>
        /// <param name="total">总记录数</param>
        /// <param name="productId">云服务商id</param>
        /// <returns></returns>
        private IList<CommentViewModel> GetCommentList(int pageIndex, int pageSize, out int total, int productId)
        {
            return _commentService.LoadEntitiesPaging(pageIndex, pageSize, out total, m => m.CloudProduct.Id == productId, m => m.CommentTime, true).Select(m => new CommentViewModel
            {
                Content = m.Content,
                CommentTime = m.CommentTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Commentator = m.Commentator.UserName,
                Score = m.Score
            })?.ToList();
        }

        // POST：提交评论
        [HttpPost]
        public async Task<IActionResult> CommentOn(CommentInputViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Json(new { success = false, message = "你未登录，正在为你跳转到登录页！", code = 403 });
            }
            if (ModelState.IsValid)
            {
                if (_commentService.LoadEntity(m => m.Commentator.Id == user.Id && m.CloudProduct.Id == viewModel.ProductId) != null)
                {
                    return Json(new { success = false, message = "你已经点评过该产品了，不能重复点评，可以去补充您的点评！" });
                }
                var product = _cloudProductService.LoadEntity(m => m.Id == viewModel.ProductId);
                if (product != null)
                {
                    var comment = _commentService.AddEntity(new Comment
                    {
                        Commentator = user,
                        Content = viewModel.Content,
                        Score = viewModel.Score,
                        CloudProduct = product
                    });
                    if (_commentService.SaveChanges())
                    {
                        return Json(new { success = true, message = "点评成功！", data = comment.ToViewModel() });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "该服务商不存在，刷新后重试！" });
                }
            }

            return Json(new { success = false, message = "请认真填写点评！" });
        }
    }
}
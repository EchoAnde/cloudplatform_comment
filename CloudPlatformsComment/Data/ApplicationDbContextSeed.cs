using CloudPlatformsComment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Data
{
    public class ApplicationDbContextSeed
    {
        private UserManager<ApplicationUser> _userManager;

        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider services)
        {
            // 初始化用户
            if (!context.Users.Any())
            {
                _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                var defaultUser = new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "demo@123.com",
                    NormalizedUserName = "admin"
                };

                var result = await _userManager.CreateAsync(defaultUser, "Password$123");
                if (!result.Succeeded)
                {
                    throw new Exception("初始默认用户失败");
                }
            }
            // 初始化云服务商
            if (!context.CloudPlatforms.Any())
            {
                var platforms = new List<CloudPlatform>
                {
                    new CloudPlatform
                    {
                        PlatformName = "阿里云",
                        Description = "为了无法计算的价值",
                        Logo = "/resources/images/aliyun.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "腾讯云",
                        Description = "连接智能未来",
                        Logo = "/resources/images/Tencent.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "百度云",
                        Description = "智能，计算无限可能",
                        Logo = "/resources/images/baidu.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "Microsoft Azure",
                        Description = "安全可信_灵活开源_经济高效的云平台",
                        Logo = "/resources/images/Azure.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "亚马逊AWS",
                        Description = "亚马逊公司旗下云计算服务平台",
                        Logo = "/resources/images/AWS.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "网易蜂巢",
                        Description = "新一代云计算平台",
                        Logo = "/resources/images/163yun.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "滴滴云",
                        Description = "为开发者而生",
                        Logo = "/resources/images/didiyun.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "华为云",
                        Description = "联接企业现在与未来",
                        Logo = "/resources/images/huaweiyun.jpg"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "小鸟云",
                        Description = "国内卓越的云计算服务提供商",
                        Logo = "/resources/images/niaoyun.png"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "七牛云",
                        Description = "国内领先的企业级云服务商",
                        Logo = "/resources/images/qiniu.png"
                    },
                    new CloudPlatform
                    {
                        PlatformName = "UCloud",
                        Description = "中国领先的中立云计算服务商",
                        Logo = "/resources/images/ucloud.jpg"
                    }
                };

                await context.CloudPlatforms.AddRangeAsync(platforms);
                var result = await context.SaveChangesAsync();
                if (result <= 0)
                {
                    throw new Exception("初始默认用户失败");
                }
            }

            var drop = "if ((select COUNT(*) from dbo.sysobjects where id = object_id(N'[dbo].[v_cloudplatform]') and OBJECTPROPERTY(id, N'IsView')=1)=1) drop view [dbo].[v_cloudplatform];";

            context.Database.ExecuteSqlCommand(drop);

            var createView = @"CREATE VIEW [dbo].[v_cloudplatform] 
                AS SELECT Id, Description, Logo, PlatformName, ISNULL([Count],0) as [Count], ISNULL([Score],5) as Score from [dbo].[CloudPlatforms] a
	            left join (select CloudPlatformId,COUNT(*) as [Count], AVG(Score) as Score from [dbo].[Comments] group by CloudPlatformId
	            ) b on a.Id=b.CloudPlatformId";

            context.Database.ExecuteSqlCommand(createView);
        }
    }
}

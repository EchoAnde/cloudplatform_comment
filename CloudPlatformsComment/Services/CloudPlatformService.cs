using CloudPlatformsComment.Data;
using CloudPlatformsComment.IServices;
using CloudPlatformsComment.Models;
using CloudPlatformsComment.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Services
{
    public class CloudPlatformService : BaseService<CloudPlatform>, ICloudPlatformService
    {
        private ApplicationDbContext _context;
        public CloudPlatformService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<CloudPlatformListView> GetAllCloudPlatformList()
        {

            //IList<CloudPlatformListViewModel> result = null;
            //var platforms = base.LoadEntities(p => true);
            //if (platforms != null)
            //{
            //    result = new List<CloudPlatformListViewModel>();
            //    IQueryable<Comment> comments;
            //    var count = 0;
            //    foreach (var platform in platforms)
            //    {

            //        comments = _context.Entry(platform)
            //            .Collection(m => m.Comments)
            //            .Query();
            //        count = comments.Count();
            //        result.Add(new CloudPlatformListViewModel
            //        {
            //            Count = count,
            //            Description = platform.Description,
            //            PlatformName = platform.PlatformName,
            //            Id = platform.Id,
            //            Logo = platform.Logo,
            //            Score = count != 0 ? comments.Sum(c => c.Score) / count : 5.0d
            //        });
            //    }
            //}
            //return result;

            //return _context.CloudPlatformList.Where(c => true).OrderBy(c => c.Id)?.ToList();
            return _context.CloudPlatformList.FromSql("select * from [dbo].[v_cloudplatform]")?.ToList();
        }

        public CloudPlatform FindById(int id)
        {
            return _context.CloudPlatforms.FirstOrDefault(m => m.Id == id);
        }
    }
}

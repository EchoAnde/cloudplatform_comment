using CloudPlatformsComment.Data;
using CloudPlatformsComment.IServices;
using CloudPlatformsComment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Services
{
    public class CloudProductService : BaseService<CloudProduct>, ICloudProductService
    {
        private readonly ApplicationDbContext _context;
        public CloudProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public CloudProduct FindById(int id)
        {
            return _context.CloudProducts.Include(m => m.CloudPlatform).FirstOrDefault(m => m.Id == id);
        }
    }
}

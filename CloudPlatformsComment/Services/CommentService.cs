using CloudPlatformsComment.Data;
using CloudPlatformsComment.IServices;
using CloudPlatformsComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

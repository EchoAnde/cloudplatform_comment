using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }

        public string CommentTime { get; set; }

        public string Commentator { get; set; }

        public double Score { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class CommentListViewModel
    {
        public string PlatformName { get; set; }


        public string Description { get; set; }

        public string Image { get; set; }

        public int TotalCount { get; set; }

        public IList<CommentViewModel> Comments { get; set; }

        public int PlatformId { get; set; }
    }
}

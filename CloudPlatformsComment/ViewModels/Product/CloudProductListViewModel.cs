using CloudPlatformsComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class CloudProductListViewModel
    {
        public string PlatformName { get; set; }

        public int PlatformId { get; set; }

        public IList<CloudProduct> Products { get; set; }
    }
}

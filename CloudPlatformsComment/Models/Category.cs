using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Models
{
    /// <summary>
    /// 产品类型
    /// </summary>
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CloudProduct> CloudProducts { get; set; }
    }
}

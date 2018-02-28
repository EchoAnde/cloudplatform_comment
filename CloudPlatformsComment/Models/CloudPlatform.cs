using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Models
{
    /// <summary>
    /// 云服务商
    /// </summary>
    public class CloudPlatform
    {
        public CloudPlatform()
        {
            //Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// logo图片地址
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<CloudProduct> Products { get; set; }
    }
}

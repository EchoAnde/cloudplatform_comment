using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Models
{
    /// <summary>
    /// 云产品
    /// </summary>
    public class CloudProduct
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public virtual CloudPlatform CloudPlatform { get; set; }

        public virtual Category Category { get; set; }
    }
}

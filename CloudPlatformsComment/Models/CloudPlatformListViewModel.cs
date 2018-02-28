using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment
{
    public class CloudPlatformListView
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 服务商名称
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// 服务商描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 平均评分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// logo图片地址
        /// </summary>
        public string Logo { get; set; }
    }
}

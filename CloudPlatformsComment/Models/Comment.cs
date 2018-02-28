using CloudPlatformsComment.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.Models
{
    public class Comment
    {
        public Comment()
        {
            CommentTime = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public double Score { get; set; }
        
        public virtual CloudProduct CloudProduct { get; set; }
        
        public virtual ApplicationUser Commentator { get; set; }

        public CommentViewModel ToViewModel()
        {
            return new CommentViewModel
            {
                Commentator = Commentator.UserName,
                CommentTime = CommentTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Content = Content,
                Score = Score
            };
        }
    }
}

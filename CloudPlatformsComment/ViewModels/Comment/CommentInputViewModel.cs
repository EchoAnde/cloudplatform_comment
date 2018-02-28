using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class CommentInputViewModel
    {

        [Required(ErrorMessage = "内容必须填写！")]
        public string Content { get; set; }

        [Required(ErrorMessage ="必须评分！")]
        public double Score { get; set; }

        public int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "邮箱不能为空！")]
        [DataType(DataType.EmailAddress, ErrorMessage = "请填写正确的邮箱格式！")]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "密码不能为空！")]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }
    }
}

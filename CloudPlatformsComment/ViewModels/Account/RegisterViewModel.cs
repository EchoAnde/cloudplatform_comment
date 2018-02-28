using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPlatformsComment.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage ="邮箱不能为空")]
        [DataType(DataType.EmailAddress, ErrorMessage ="请输入正确的邮箱格式！")]
        [DisplayName("注册邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage ="密码不能为空")]
        [DataType(DataType.Password)]
        [DisplayName("设置密码")]
        public string Password { get; set; }

        [Required(ErrorMessage ="请确认您的密码。")]
        [DataType(DataType.Password)]
        [DisplayName("重复密码")]
        [Compare("Password", ErrorMessage ="两次输入的密码不一致，请重新输入！")]
        public string ConfirmedPassword { get; set; }
    }
}

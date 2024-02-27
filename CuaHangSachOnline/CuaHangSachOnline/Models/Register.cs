using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuaHangSachOnline.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Tài khoản không được để trống!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mật khẩu nhập lại không được để trống!")]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu nhập lại không giống nhau")]
        public string ConfirmPassword { get; set; }
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        public string Email { get; set; }

        public string Sdt { get; set; }
    }
}
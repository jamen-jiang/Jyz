using System.ComponentModel.DataAnnotations;

namespace Jyz.Application.Dtos
{
    public class LoginInfo
    {
        [Display(Name = "用户名")]
        [MaxLength(50)]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string PassWord { get; set; }
    }
}

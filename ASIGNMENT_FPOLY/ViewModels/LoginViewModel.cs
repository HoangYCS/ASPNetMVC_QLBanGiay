using System.ComponentModel.DataAnnotations;

namespace ASIGNMENT_FPOLY.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Vui lòng nhập UserName")]
        [MinLength(5, ErrorMessage = "UserName phải chứa ít nhất 6 ký tự.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập PassWord")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "PassWord không được chứa kí tự đặc biệt")]
        [MinLength(6, ErrorMessage = "PassWord phải chứa ít nhất 6 ký tự.")]
        public string PassWord { get; set; }
    }
}

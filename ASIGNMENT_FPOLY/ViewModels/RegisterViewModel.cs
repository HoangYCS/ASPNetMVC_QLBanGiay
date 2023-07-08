using System.ComponentModel.DataAnnotations;

namespace ASIGNMENT_FPOLY.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui long nhap username")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Vui long nhap mat khau")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

    }
}

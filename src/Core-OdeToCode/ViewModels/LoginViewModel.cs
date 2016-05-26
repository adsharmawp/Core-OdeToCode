using System.ComponentModel.DataAnnotations;

namespace Core_OdeToCode.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool Remember { get; set; }

        public string ReturnUrl { get; set; }
    }
}

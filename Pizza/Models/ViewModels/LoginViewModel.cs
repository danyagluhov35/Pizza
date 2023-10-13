using Pizza.Context;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не введен логин")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Не введен пароль")]
        public string? Password { get; set; }
        public string? IsValidUser { get; set; }
    }
}

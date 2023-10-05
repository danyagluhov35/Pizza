using Pizza.Context;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models.ViewModels
{
    public class LoginViewModel
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}

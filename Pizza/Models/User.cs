using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza.Models
{
    public partial class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не введен логин")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Не введен пароль")]
        public string? Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}

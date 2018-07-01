using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не введено Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не введено пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [Required(ErrorMessage = "Введите Email")]
        [MinLength(10, ErrorMessage = "Адрес не может быть короче 10 символов")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}

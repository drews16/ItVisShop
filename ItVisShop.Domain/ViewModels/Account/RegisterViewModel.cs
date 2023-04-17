using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Имя должно быть не больше 20 символов")]
        [MinLength(3, ErrorMessage = "Имя не может быть короче 3 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите фамилию")]
        [MaxLength(30, ErrorMessage = "Фамилия должно быть не больше 30 символов")]
        [MinLength(2, ErrorMessage = "Фамилия не может быть короче 3 символов")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный Email")]
        [Required(ErrorMessage = "Укажите Email")]
        [MinLength(9, ErrorMessage = "Адрес не может быть короче 9 символов")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Неверный формат телефона")]
        [Required(ErrorMessage = "Укажите телефон")]
        [MaxLength(12, ErrorMessage = "Телефон не может быть длиннее 12 символов")]
        [MinLength(11, ErrorMessage = "Телефон не может быть короче 11 символов")]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage="Пароль не должен быть короче 8 символов")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Укажите пароль")]
        public string? PasswordConfirm { get; set; }
    }
}

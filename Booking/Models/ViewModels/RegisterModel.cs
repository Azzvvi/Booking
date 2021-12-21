using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.ViewModels
{
    //класс для регистрации пользователя в системе
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string name { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        public string login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Пароль введен неверно")]
        public string confirmPassword { get; set; }
    }
}

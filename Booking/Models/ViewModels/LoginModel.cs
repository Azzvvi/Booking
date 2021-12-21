using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.ViewModels
{
    //класс для входа пользователя в систему
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}

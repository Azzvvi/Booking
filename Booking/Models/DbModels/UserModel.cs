using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.DbModels
{
    //класс-модель бд
    public class UserModel
    {
        [Column(TypeName="serial")]
        public int id { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string login { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string password{ get; set; }
        [Column(TypeName = "varchar(25)")]
        public string name { get; set; }
    }
}

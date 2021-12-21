using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.DbModels
{
    //класс-модель бд
    public class RoomModel
    {
        [Column(TypeName = "serial")]
        public int id { get; set; }
        [Column(TypeName = "int")]
        public int hotel_id { get; set; }
        [Column(TypeName = "int")]
        public int seats { get; set; }
        [Column(TypeName = "int")]
        public int price { get; set; }
        [Column(TypeName = "date")]
        public DateTime begin_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }
    }
}

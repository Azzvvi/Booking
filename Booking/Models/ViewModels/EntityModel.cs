using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.ViewModels
{
    //класс для представления информации о номере 
    public class EntityModel
    {
        public string hotel_name { get; set; }
        public int room_id { get; set; }
        public int seats { get; set; }
        public int price { get; set; }
    }
}

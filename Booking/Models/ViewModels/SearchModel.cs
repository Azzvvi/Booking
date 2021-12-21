using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.ViewModels
{
    public class SearchModel
    {
        public string city { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int seats { get; set; }
    }
}

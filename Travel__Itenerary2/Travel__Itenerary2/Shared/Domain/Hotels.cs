using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Hotels : BaseDomainModel
    {
       
        public string HotelName { get; set; }
        public int HotelPrice { get; set; }
        public string HotelAddress { get; set; }
        public DateTime HotelCheckIn { get; set; }
        public DateTime HotelCheckOut { get; set; }
        public virtual List<Bookings> Bookings { get; set; }

    }
}

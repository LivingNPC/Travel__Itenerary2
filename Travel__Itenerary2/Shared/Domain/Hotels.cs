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
        public string HotelDesc { get; set; }
        public string HotelAddress { get; set; }
        public virtual List<Bookings> Bookings { get; set; }


    }
}
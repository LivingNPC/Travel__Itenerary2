using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Flights : BaseDomainModel
    {
        public string FlightName { get; set; }
        public string FlightClass { get; set; }
        public string FlightDesc { get; set; }
        public string FlightDestination { get; set; }
        public int FlightPrice { get; set; }

        public DateTime FlightDepartDate { get; set; }
        public DateTime FlightReturnDate { get; set; }

        public virtual List<Bookings> Bookings { get; set; }
    }

    
}

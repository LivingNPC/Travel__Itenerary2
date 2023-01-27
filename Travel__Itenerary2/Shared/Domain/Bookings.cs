using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Bookings : BaseDomainModel
    {
        public DateTime DateTime { get; set; }
        public DateTime FlightDepartDate { get; set; }
        public DateTime FlightReturnDate { get; set; }
        public DateTime PackageStart { get; set; }
        public DateTime PackageEnd { get; set; }
        public DateTime HotelCheckIn { get; set; }
        public DateTime HotelCheckOut { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int CustId { get; set; }
        public virtual Customers Customers { get; set; }
        public int HotelId { get; set; }
        public virtual Hotels Hotels { get; set; }
        public int FlightId { get; set; }
        public virtual Flights Flights { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Payments : BaseDomainModel
    {
       
        public string PayDescription { get; set; }
        public DateTime PayDate { get; set; }
        public int BookingId { get; set; }
        public virtual Bookings Bookings { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
      /*  public int HotelId { get; set; }
        public virtual Hotels Hotels { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int FlightsId { get; set; }
        public virtual Flights Flights { get; set; }*/
    }
}

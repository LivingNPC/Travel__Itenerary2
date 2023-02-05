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

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int CustomersId { get; set; }
        public virtual Customers Customers { get; set; }
        public int HotelsId { get; set; }
        public virtual Hotels Hotels { get; set; }
        public int FlightsId { get; set; }
        public virtual Flights Flights { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual List<Payments> Payments { get; set; }


    }
}

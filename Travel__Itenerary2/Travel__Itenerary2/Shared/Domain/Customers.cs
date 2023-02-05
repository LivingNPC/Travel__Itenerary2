using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Customers : BaseDomainModel
    {
        public string NRIC { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Bookings> Bookings { get; set; }
    }


}


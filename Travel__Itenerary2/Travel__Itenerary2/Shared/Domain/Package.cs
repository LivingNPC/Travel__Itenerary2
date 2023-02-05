using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Package : BaseDomainModel
    {
       
        public string PackageName { get; set; }
        public int PackagePrice { get; set; }
        public string PackageDescription { get; set; }
        public DateTime PackageStart { get; set; }
        public DateTime PackageEnd { get; set; }
        public virtual List<Bookings> Bookings { get; set; }


    }
}

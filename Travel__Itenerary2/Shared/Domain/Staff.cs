using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Shared.Domain
{
    public class Staff : BaseDomainModel
    {

        public string Name { get; set; }
        public int Address { get; set; }
        public int ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
    }
}
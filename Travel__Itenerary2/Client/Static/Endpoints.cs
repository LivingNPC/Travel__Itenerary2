using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Client.Static
{
    public static class Endpoints
    {

        private static readonly string Prefix = "api";

        public static readonly string FlightsEndpoint = $"{Prefix}/Flights";
        public static readonly string HotelsEndpoint = $"{Prefix}/Hotels";
        public static readonly string PackageEndpoint = $"{Prefix}/Package";
        public static readonly string CustomersEndpoint = $"{Prefix}/Customers";
        public static readonly string PaymentsEndpoint = $"{Prefix}/Payments";
        public static readonly string StaffEndpoint = $"{Prefix}/Staff";
        public static readonly string BookingsEndpoint = $"{Prefix}/Bookings";

    }
}


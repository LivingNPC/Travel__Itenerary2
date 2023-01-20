using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel__Itenerary2.Shared.Domain;


namespace Travel__Itenerary2.Server.Configurations.Entities
{
    public class FlightSeedConfiguration : IEntityTypeConfiguration<Flights>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flights> builder)
        {
            builder.HasData(
        new Flights
        {
            Id = 1,
            FlightName = "Singapore Airlines",
            FlightClass = "First-Class",
            FlightDesc = "First class is a premium class of service on an airplane, offering the highest level of comfort, amenities, and service ",
            FlightDestination = "Portugal"
        },

        new Flights
        {
            Id = 2,
            FlightName = "Singapore Airlines",
            FlightClass = "Business-Class",
            FlightDesc = "Business class is a class of service on an airplane that is nothing short for comfort",
            FlightDestination = "Belgium"

        },

        new Flights
        {
            Id = 3,
            FlightName = "Singapore Airlines",
            FlightClass = "Economy-Class",
            FlightDesc = "Economy class is a class of service on an airplane that offers the basic standards",
            FlightDestination = "Japan"
        }
        );

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel__Itenerary2.Shared.Domain;

namespace Travel__Itenerary2.Server.Configurations.Entities
{
    public class HotelSeedConfiguration : IEntityTypeConfiguration<Hotels>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotels> builder)
        {
            DataBuilder<Hotels> dataBuilder = builder.HasData(
        new Hotels
        {
            Id = 1,
            HotelName = "Hotel Mundial",
            HotelPrice = 296,
            HotelAddress = "Praça Martim Moniz 2, 1100-341 Lisboa, Portugal"
        },

        new Hotels
        {
            Id = 2,
            HotelName = "MEININGER Hotel Bruxelles Gare du Midi",
            HotelPrice = 74,
            HotelAddress = "Rue Bara 101, 1070 Brussels, Belgium"
        },

        new Hotels
        {
            Id = 3,
            HotelName = "Shinagawa Prince Hotel",
            HotelPrice = 145,
            HotelAddress = "4 Chome-10-30 Takanawa, Minato City, Tokyo 108-6111, Japan"
        }
        );
        }
    }
}
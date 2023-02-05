using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel__Itenerary2.Shared.Domain;

namespace Travel__Itenerary2.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customers> builder)
        {
            builder.HasData(
        new Customers
        {
            Id = 1,
            NRIC = "T073289F",
            Address= "Sengkang 545960",
            ContactNumber = 91290002,
            EmailAddress = "janna133@gmail.com",
           
        },
        new Customers
        {
            Id = 2,
            NRIC = "S103443F",
            Address = "Ang Mo kio 450654",
            ContactNumber = 81233343,
            EmailAddress = "margeretjane322@gmail.com",
            
        },
        new Customers
        {
            Id = 3,
            NRIC = "S103323D",
            Address = "Temasek 902009",
            ContactNumber = 90311109,
            EmailAddress = "SammyBoi0122@gmail.com",
            
        }
        );

        }
    }
}
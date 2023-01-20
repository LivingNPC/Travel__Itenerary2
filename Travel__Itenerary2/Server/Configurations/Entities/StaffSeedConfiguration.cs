using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel__Itenerary2.Shared.Domain;

namespace Travel__Itenerary2.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
        new Staff
        {
            Id = 1,
            Name = "John",
            Address = 823616,
            ContactNumber = 91233219,
            EmailAddress = "johndoe123@gmail.com",
            Position = "CEO"
        },
        new Staff
        {
            Id = 2,
            Name = "Mary",
            Address = 712321,
            ContactNumber = 81233218,
            EmailAddress = "maryjane321@gmail.com",
            Position = "Customer Service"
        },
        new Staff
        {
            Id = 3,
            Name = "Peter",
            Address = 612321,
            ContactNumber = 90000009,
            EmailAddress = "peterparker0123@gmail.com",
            Position = "Payment Handler"
        }
        );

        }
    }
}
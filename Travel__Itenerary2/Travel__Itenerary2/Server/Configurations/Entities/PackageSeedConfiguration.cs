using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel__Itenerary2.Shared.Domain;

namespace Travel__Itenerary2.Server.Configurations.Entities
{
    public class PackageSeedConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Package> builder)
        {
            builder.HasData(
        new Package
        {
            Id = 1,
            PackageName = "Lisboa_Tour",
            PackagePrice = 800,
            PackageDescription = "Lisbon, also known as Lisboa, is the capital and largest city of Portugal. It is located on the Atlantic coast of the Iberian Peninsula and is known for its historic architecture, lively cultural scene, and picturesque neighborhoods.",
         
        },
        new Package
        {
            Id = 2,
            PackageName = "Brussel_Tour",
            PackagePrice = 890,
            PackageDescription = "Brussels is the capital and largest city of Belgium, and serves as the administrative center of the European Union. It is located in the center of the country and is known for its historic architecture, including the Grand Place, a UNESCO World Heritage site.",
        
        },
        new Package
        {
            Id = 3,
            PackageName = "Tokyo_Tour",
            PackagePrice = 1000,
            PackageDescription = "Tokyo is the capital and largest city of Japan. It is located in the eastern part of the main island of Honshu and is considered one of the most populous cities in the world. Tokyo is known for its vibrant culture, cutting-edge technology, and unique blend of modern and traditional elements.",
            
        }
        );

        }
    }
}
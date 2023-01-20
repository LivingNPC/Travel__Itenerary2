using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Travel__Itenerary2.Server.Configurations.Entities;
using Travel__Itenerary2.Server.Models;
using Travel__Itenerary2.Shared.Domain;
using Travel_Itenerary2.Server.Configurations.Entities;

namespace Travel__Itenerary2.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new HotelSeedConfiguration());
            builder.ApplyConfiguration(new FlightSeedConfiguration());
            builder.ApplyConfiguration(new PackageSeedConfiguration());
            builder.ApplyConfiguration(new StaffSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
        }
    }
}

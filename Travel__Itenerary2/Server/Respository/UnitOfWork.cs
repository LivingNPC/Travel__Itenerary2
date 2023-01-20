using Travel__Itenerary2.Server.Data;
using Travel__Itenerary2.Server.IRepository;
using Travel__Itenerary2.Server.Models;
using Travel__Itenerary2.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Bookings> _Bookings;
        private IGenericRepository<Customers> _Customers;
        private IGenericRepository<Flights> _Flights;
        private IGenericRepository<Hotels> _Hotels;
        private IGenericRepository<Package> _Package;
        private IGenericRepository<Payments> _Payments;
        private IGenericRepository<Staff> _Staff;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Bookings> Bookings
            => _Bookings ??= new GenericRepository<Bookings>(_context);
        public IGenericRepository<Customers> Customers 
            => _Customers ??= new GenericRepository<Customers>(_context);
        public IGenericRepository<Flights> Colours
            => _Flights ??= new GenericRepository<Flights>(_context);
        public IGenericRepository<Hotels> Hotels
            => _Hotels ??= new GenericRepository<Hotels>(_context);
        public IGenericRepository<Package> Package
            => _Package ??= new GenericRepository<Package>(_context);
        public IGenericRepository<Payments> Payments
            => _Payments ??= new GenericRepository<Payments>(_context);
        public IGenericRepository<Staff> Staff
           => _Staff ??= new GenericRepository<Staff>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
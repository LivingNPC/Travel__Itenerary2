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
        private IGenericRepository<Bookings> _bookings;
        private IGenericRepository<Customers> _customers;
        private IGenericRepository<Flights> _flights;
        private IGenericRepository<Hotels> _hotels;
        private IGenericRepository<Package> _packages;
        private IGenericRepository<Payments> _payments;
        private IGenericRepository<Staff> _staffs;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Bookings> Bookings
            => _bookings ??= new GenericRepository<Bookings>(_context);
        public IGenericRepository<Customers> Customers
            => _customers ??= new GenericRepository<Customers>(_context);
        public IGenericRepository<Flights> Flights
            => _flights ??= new GenericRepository<Flights>(_context);
        public IGenericRepository<Hotels> Hotels
            => _hotels ??= new GenericRepository<Hotels>(_context);
        public IGenericRepository<Package> Packages
            => _packages ??= new GenericRepository<Package>(_context);
        public IGenericRepository<Payments> Payments
            => _payments ??= new GenericRepository<Payments>(_context);
        public IGenericRepository<Staff> Staffs
           => _staffs ??= new GenericRepository<Staff>(_context);

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

            

            await _context.SaveChangesAsync();
        }
    }
}
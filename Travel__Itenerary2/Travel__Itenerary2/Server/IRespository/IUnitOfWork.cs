using Travel__Itenerary2.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Travel__Itenerary2.Server.IRepository;

namespace Travel__Itenerary2.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Bookings> Booking { get; }
        IGenericRepository<Customers> Customer { get; }
        IGenericRepository<Flights> Flight { get; }
        IGenericRepository<Hotels> Hotel { get; }
        IGenericRepository<Package> Packages { get; }
        IGenericRepository<Payments> Payment { get; }
        IGenericRepository<Staff> Staffs { get; }
    }
}
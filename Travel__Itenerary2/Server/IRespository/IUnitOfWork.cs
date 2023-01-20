using Travel__Itenerary2.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Travel__Itenerary2.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Bookings> Bookings { get; }
        IGenericRepository<Customers> Customers { get; }
        IGenericRepository<Flights> Flights { get; }
        IGenericRepository<Hotels> Hotels { get; }
        IGenericRepository<Package> Packages { get; }
        IGenericRepository<Payments> Payments { get; }
        IGenericRepository<Staff> Staffs { get; }
    }
}
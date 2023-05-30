using CarRentalMgt.Server.Data;
using CarRentalMgt.Server.IRepository;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMgt.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Make> _makes;
        private IGenericRepository<Model> _models;
        private IGenericRepository<Vehicle> _vehicles;
        private IGenericRepository<Colour> _colours;
        private IGenericRepository<Booking> _bookings;
        private IGenericRepository<Customer> _customers;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Make> Makes
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _makes ??= new GenericRepository<Make>(_context);
        public IGenericRepository<Model> Models
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _models ??= new GenericRepository<Model>(_context);
        public IGenericRepository<Vehicle> Vehicles
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _vehicles ??= new GenericRepository<Vehicle>(_context);
        public IGenericRepository<Colour> Colours
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _colours ??= new GenericRepository<Colour>(_context);
        public IGenericRepository<Booking> Bookings
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _bookings ??= new GenericRepository<Booking>(_context);
        public IGenericRepository<Customer> Customers
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _customers ??= new GenericRepository<Customer>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            var user = httpContext.User.Identity.Name;

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

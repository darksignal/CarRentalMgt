using CarRentalMgt.Server.Data;
using CarRentalMgt.Server.IRepository;
using CarRentalMgt.Server.Models; //DRG Added for the UserManager "ApplicationUser" below.
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        //DRG We need to inject UserManager for the new code below to work...
        private UserManager<ApplicationUser> _userManager;

        //DRG We need to initialize the USerManager we created...
        //public UnitOfWork(ApplicationDbContext context)
        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            //DRG: We are changing this because this httpContext.User.Identity does not contain the user logged in...
            //   Claim contains information about the user, "I claim I'm this or that..."............................
            //var user = httpContext.User.Identity.Name;
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);


            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);   

            foreach (var entry in entries) 
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user.UserName;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user.UserName;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}

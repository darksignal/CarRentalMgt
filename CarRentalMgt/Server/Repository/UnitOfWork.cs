using CarRentalMgt.Server.Data;
using CarRentalMgt.Server.IRepository;
using CarRentalMgt.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMgt.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Make> _makes;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Make> Makes 
            // ??= is like if(null) then a new generic repository of Make is created from Context
            => _makes ??= new GenericRepository<Make>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

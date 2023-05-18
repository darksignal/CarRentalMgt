using CarRentalMgt.Shared.Domain;

namespace CarRentalMgt.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
        IGenericRepository<Make> Makes { get; }
        //IGenericRepository<Model> Models { get; }
        //IGenericRepository<Vehicle> Vehicles { get; }
        //IGenericRepository<Colour> Colours { get; }
        //IGenericRepository<Booking> Bookings { get; }
        //IGenericRepository<Customer> Customers { get; }
    }
}

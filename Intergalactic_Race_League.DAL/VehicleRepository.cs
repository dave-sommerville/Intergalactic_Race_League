using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.DAL
{
    public class VehicleRepository
    {
        private readonly IrlDbContext _context;
        public VehicleRepository(IrlDbContext context)
        {
            _context = context;
        }
        public List<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.ToList();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
    }
}

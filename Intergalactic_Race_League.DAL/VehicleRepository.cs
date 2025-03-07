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
        public Vehicle GetVehicleById(int id)
        {
            return _context.Vehicles.Find(id);
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
        public void DeleteVehicle(int id)
        {
            Vehicle vehicle = _context.Vehicles.Find(id);
            if(vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }
    }
}

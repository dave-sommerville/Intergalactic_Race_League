using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleReposity;
        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleReposity = vehicleRepository;
        }
        public List<Vehicle> GetVehicles()
        {
            return _vehicleReposity.GetAllVehicles();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            if(string.IsNullOrWhiteSpace(vehicle.Model)) {
                throw new ArgumentException("Model cannot be empty");
            }
        }
        public Vehicle GetVehicleById(int id)
        {
            return _vehicleReposity.GetVehicleById(id);
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Model))
            {
                throw new ArgumentException("Model cannot be empty");
            }
            _vehicleReposity.UpdateVehicle(vehicle);
        }
        public void DeleteVehicle(int id)
        {
            _vehicleReposity.DeleteVehicle(id);
        }
    }
}

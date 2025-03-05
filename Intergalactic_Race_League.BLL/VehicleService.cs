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

        }
    }
}

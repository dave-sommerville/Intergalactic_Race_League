using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;
using Microsoft.Identity.Client;

namespace Intergalactic_Race_League.BLL
{
    public class RacerVehicleService
    {
        private readonly RacerRepository _racerRepository;
        private 
        public RacerVehicleService(RacerVehicleRepository racerVehicleRepository)
        {
            _racerVehicleRepository = racerVehicleRepository;
        }
        public List<RacerVehicle> GetRacerVehicles()
        {
            return _racerVehicleRepository.GetAllRacerVehicles();
        }
        public void CreateRacerVehicle(RacerVehicle racerVehicle)
        {
            Racer racer = new Racer
            {
                DriverName = racerVehicle.Racer.DriverName,
                DriverHeightInCm = racerVehicle.Racer.DriverHeightInCm
            };
            Vehicle vehicle = new Vehicle
            {
                Model = racerVehicle.Vehicle.Model,
                Type = racerVehicle.Vehicle.Type
            };
            _racerVehicleRepository.AddRacer(racer);
            _racerVehicleRepository.AddVehicle(vehicle);
            _racerVehicleRepository.SaveChanges();

        }
    }
}

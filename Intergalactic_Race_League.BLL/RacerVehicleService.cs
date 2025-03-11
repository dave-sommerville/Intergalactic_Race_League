using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;
using Microsoft.Identity.Client;

namespace Intergalactic_Race_League.BLL
{
    public class RacerVehicleService
    {
        private readonly RacerRepository _racerRepository;
        private readonly VehicleRepository _vehicleRepository;
        private readonly RacerVehicleRepository _racerVehicleRepository;
        public RacerVehicleService(RacerRepository racerRepository, VehicleRepository vehicleRepository, RacerVehicleRepository racerVehicleRepository)
        {
            _racerRepository = racerRepository;
            _vehicleRepository = vehicleRepository;
            _racerVehicleRepository = racerVehicleRepository;
        }
        public List<RacerVehicle> GetRacerVehicles()
        {
            return _racerVehicleRepository.GetAllRacerVehicles();
        }
        public RacerVehicle GetRacerVehicleById(int id)
        {
            return _racerVehicleRepository.GetRacerVehicleById(id);
        }
        public void CreateRacerVehicle(RacerVehicle racerVehicle)
        {
            _racerRepository.AddRacer(racerVehicle.Racer);
            _vehicleRepository.AddVehicle(racerVehicle.Vehicle);
            _racerVehicleRepository.AddRacerVehicle(racerVehicle);
            _racerVehicleRepository.SaveChanges();

        }
        public void UpdateRacerVehicle(RacerVehicle racerVehicle)
        {
            _racerRepository.AddRacer(racerVehicle.Racer);
            _vehicleRepository.AddVehicle(racerVehicle.Vehicle);
            _racerVehicleRepository.SaveChanges();
        }
        public void DeleteRacerVehicle(int id)
        {
            RacerVehicle racerVehicle = _racerVehicleRepository.GetRacerVehicleById(id);
            if (racerVehicle != null)
            {
                _racerVehicleRepository.RemoveRacer(racerVehicle.Racer);
                _racerVehicleRepository.RemoveVehicle(racerVehicle.Vehicle);
                _racerVehicleRepository.SaveChanges();
            }
        }
    }
}

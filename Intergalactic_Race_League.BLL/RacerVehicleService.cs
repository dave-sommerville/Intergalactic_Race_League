using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;
using Microsoft.Identity.Client;

namespace Intergalactic_Race_League.BLL
{
    public class RacerVehicleService
    {
        private readonly RacerVehicleRepository _racerVehicleRepository;
        public RacerVehicleService(RacerVehicleRepository racerVehicleRepository)
        {
            _racerVehicleRepository = racerVehicleRepository;
        }
        public List<RacerVehicle> GetRacerVehicles()
        {
            return _racerVehicleRepository.GetAllRacerVehicles();
        }
        public void AddRacerVehicle(RacerVehicle racerVehicle)
        {

        }
    }
}

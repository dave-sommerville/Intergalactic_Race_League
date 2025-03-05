using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class RacerService
    {
        private readonly RacerRepository _racerRepository;
        public RacerService(RacerRepository racerRepository)
        {
            _racerRepository = racerRepository;
        }
        public List<Racer> GetRacers()
        {
            return _racerRepository.GetAllRacers();
        }
        public void AddRacer(Racer racer)
        {

        }
    }
}

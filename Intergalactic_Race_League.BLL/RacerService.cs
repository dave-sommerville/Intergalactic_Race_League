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
        public Racer GetRacerById(int id)
        {
            return _racerRepository.GetRacerById(id);
        }
        public void UpdateRacer(Racer racer)
        {
            if (string.IsNullOrWhiteSpace(racer.Name))
            {
                throw new ArgumentException("Racer name cannot be empty");
            }
            _racerRepository.UpdateRacer(racer);
        }

    }
}

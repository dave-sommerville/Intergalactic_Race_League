using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class RaceService
    {
        private readonly RaceRepository _raceRepository;
        public RaceService(RaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public List<Race> GetRaces()
        {
            return _raceRepository.GetAllRaces();
        }
        public void AddRace(Race race)
        {

        }
    }
}

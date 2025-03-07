using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.DAL
{
    public class RaceRepository
    {
        private readonly IrlDbContext _context;
        public RaceRepository(IrlDbContext context)
        {
            _context = context;
        }
        public List<Race> GetAllRaces()
        {
            return _context.Races.ToList();
        }
        public void AddRace(Race race)
        {
            _context.Races.Add(race);
            _context.SaveChanges();
        }
        public Racer GetRacerById(int id)
        {
            return _context.Racers.Find(id);
        }
        public void UpdateRacer(Racer racer)
        {
            _context.Racers.Update(racer);
            _context.SaveChanges();
        }
    }
}

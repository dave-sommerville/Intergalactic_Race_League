using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.DAL
{
    public class RacerRepository
    {
        private readonly IrlDbContext _context;
        public RacerRepository(IrlDbContext context)
        {
            _context = context;
        }

        public List<Racer> GetAllRacers()
        {
            return _context.Racers.ToList();
        }
        public void AddRacer(Racer racer)
        {
            _context.Racers.Add(racer);
            _context.SaveChanges();
        }
    }
}

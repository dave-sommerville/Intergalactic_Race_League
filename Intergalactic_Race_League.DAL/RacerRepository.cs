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
        public Racer GetRacerById(int id)
        {
            return _context.Racers.Find(id);
        }
        public void UpdateRacer(Racer racer)
        {
            _context.Racers.Update(racer);
            _context.SaveChanges();
        }
        public void DeleteRacer(int id)
        {
            Racer racer = _context.Racers.Find(id);
            if (racer != null)
            {
                _context.Racers.Remove(racer);
                _context.SaveChanges();
            }
        }
    }
}

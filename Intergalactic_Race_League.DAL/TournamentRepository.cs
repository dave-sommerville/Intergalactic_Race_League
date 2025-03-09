using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.DAL
{
    public class TournamentRepository
    {
        private readonly IrlDbContext _context;
        public TournamentRepository(IrlDbContext context)
        {
            _context = context;
        }
        public List<Tournament> GetAllTournamnets()
        {
            return _context.Tournaments.ToList();
        }
        public List<RacerVehicle> GetAllRacerVehicles()
        {
            return _context.RacerVehicles.ToList();
        }
        public void AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }
        public Tournament GetTournamentById(int id)
        {
            return _context.Tournaments.Find(id);
        }
        public void UpdateTournament(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            _context.SaveChanges();
        }
        public void DeleteTournament(int id)
        {
            Tournament tournament = _context.Tournaments.Find(id);
            if (tournament != null)
            {
                _context.Remove(tournament);
                _context.SaveChanges();
            }
        }
    }
}

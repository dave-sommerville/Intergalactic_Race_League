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
        public void AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }
    }
}

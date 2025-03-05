using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        public TournamentService(TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
        public List<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAllTournamnets();
        }
        public void AddTournament(Tournament tournament)
        {

        }
    }
}

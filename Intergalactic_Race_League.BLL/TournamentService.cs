using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        // I think
        private readonly RaceRepository _raceRepository;
        public TournamentService(TournamentRepository tournamentRepository, RaceRepository raceRepository)
        {
            _tournamentRepository = tournamentRepository;
            _raceRepository = raceRepository;
        }
        public List<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAllTournamnets();
        }
        public void AddTournament(Tournament tournament)
        {
            if(string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Tournament must have a title");
            }
        }
        public Tournament GetTournamentById(int id)
        {
            return _tournamentRepository.GetTournamentById(id);
        }
        public void UpdateTournament(Tournament tournament)
        {
            if (string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Tournament must have a title");
            }
            _tournamentRepository.UpdateTournament(tournament);
        }
        public void DeleteRacer(int id)
        {
            _tournamentRepository.DeleteTournament(id);
        }
    }
}

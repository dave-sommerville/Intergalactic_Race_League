using Intergalactic_Race_League.DAL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        private readonly RacerVehicleRepository _racerVehicleRepository;
        // I think
        private readonly RaceRepository _raceRepository;
        public TournamentService(TournamentRepository tournamentRepository, RaceRepository raceRepository, RacerVehicleRepository racerVehicleRepository)
        {
            _tournamentRepository = tournamentRepository;
            _raceRepository = raceRepository;
            _racerVehicleRepository = racerVehicleRepository;
        }
        public List<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAllTournamnets();
        }
        public List<RacerVehicle> GetRacerVehicles()
        {
            return _racerVehicleRepository.GetAllRacerVehicles();
        }
        public List<Race> GetRaces()
        {
            return _raceRepository.GetAllRaces();
        }
        public Tournament GetTournamentById(int id)
        {
            return _tournamentRepository.GetTournamentById(id);
        }
        public void AddTournament(Tournament tournament)
        {
            if(string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Tournament must have a title");
            }
        }
        public void UpdateTournament(Tournament tournament)
        {
            if (string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Tournament must have a title");
            }
            _tournamentRepository.UpdateTournament(tournament);
        }
        public void DeleteTournament(int id)
        {
            _tournamentRepository.DeleteTournament(id);
        }
    }
}

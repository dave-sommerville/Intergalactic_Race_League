using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.Controllers
{
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;
        private readonly RaceService _raceService;
        public TournamentController(TournamentService tournamentService, RaceService raceService)
        {
            _tournamentService = tournamentService;
            _raceService = raceService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournaments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            if(ModelState.IsValid)
            {
                Tournament newTournament = new Tournament
                {
                    // Add properties 
                };
                _tournamentService.AddTournament(newTournament);
                return RedirectToAction("Index"); 
            }
            return View(tournament);
        }
    }
}

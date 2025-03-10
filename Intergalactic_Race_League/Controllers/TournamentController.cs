using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intergalactic_Race_League.Controllers
{
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;
        private readonly RaceService _raceService;
        private readonly RacerVehicleService _racerVehicleService;
        public TournamentController(TournamentService tournamentService, RaceService raceService, RacerVehicleService racerVehicleService)
        {
            _tournamentService = tournamentService;
            _raceService = raceService;
            _racerVehicleService = racerVehicleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournaments);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Tournament tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            ViewBag.Races = _tournamentService.GetRaces();
            ViewBag.RacerVehicles = _tournamentService.GetRacerVehicles();
            return View(tournament);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var racerVehicles = _racerVehicleService.GetRacerVehicles();
            ViewBag.RacerVehicles = new SelectList(racerVehicles, "RacerVehicleId", "Racer.RacerName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tournament tournament, int[] selectedRacerVehicles)
        {
            if (ModelState.IsValid)
            {
                tournament.RacerVehicles = selectedRacerVehicles.Select(id => _racerVehicleService.GetRacerVehicleById(id)).ToList();
                _tournamentService.AddTournament(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tournament tournament = _tournamentService.GetTournamentById(id);
            if(tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.UpdateTournament(tournament);
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _tournamentService.DeleteTournament(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

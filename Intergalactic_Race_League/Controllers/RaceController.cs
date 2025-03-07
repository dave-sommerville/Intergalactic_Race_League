using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.Controllers
{
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;
        public RaceController(RaceService raceService)
        {
            _raceService = raceService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Race> races = _raceService.GetRaces();
            return View(races);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Race race)
        {
            if(ModelState.IsValid)
            {
                Race newRace = new Race
                {
                    // Add properties 
                };
                _raceService.AddRace(newRace);
                return RedirectToAction("Index");
            }
            return View(race);
        }
    }
}

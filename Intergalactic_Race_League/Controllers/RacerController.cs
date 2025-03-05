using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.Controllers
{
    public class RacerController : Controller
    {
        private readonly RacerService _racerService;
        public RacerController(RacerService racerService)
        {
            _racerService = racerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Racer> racers = _racerService.GetRacers();
            return View(racers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Racer racer)
        {
            if (ModelState.IsValid)
            {
                Racer newRacer = new Racer
                {
                    // Add Properties here
                };
                _racerService.AddRacer(newRacer);
                return RedirectToAction("Index");
            }
            return View(racer);
        }
        // Need edit and delete
    }
}

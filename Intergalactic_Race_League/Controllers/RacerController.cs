using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;
using Intergalactic_Race_League.DAL;

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
            //ViewBag. options 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Racer racer)
        {
            if (ModelState.IsValid)
            {
                Racer newRacer = new Racer
                {
                    DriverName = racer.DriverName,
                    DriverAge = racer.DriverAge,
                    DriverHeightInCm = racer.DriverHeightInCm,
                    DriverCountry = racer.DriverCountry
                };
                _racerService.AddRacer(newRacer);
                return RedirectToAction("Index");
            }
            return View(racer);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Racer racer = _racerService.GetRacerById(id);
            if (racer == null)
            {
                return NotFound();
            }
            return View(racer);
        }
        [HttpPost]
        public IActionResult Edit(Racer racer)
        {
            if (ModelState.IsValid)
            {
                return View(racer);
            }
            _racerService.UpdateRacer(racer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Racer racer = _racerService.GetRacerById(id);
            if (racer == null)
            {
                return NotFound();
            }
            return View(racer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {   // Could use try catch 
            _racerService.DeleteRacer(id);
            return RedirectToAction("Index");
        }
    }
}

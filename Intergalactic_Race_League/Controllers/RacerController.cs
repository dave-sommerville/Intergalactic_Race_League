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
        public IActionResult Details(int id)
        {
            Racer racer = _racerService.GetRacerById(id);
            if (racer == null)
            {
                return NotFound();
            }
            return View(racer);
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

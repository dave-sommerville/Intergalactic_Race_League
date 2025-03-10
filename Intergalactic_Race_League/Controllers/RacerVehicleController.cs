using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.Controllers
{
    public class RacerVehicleController : Controller
    {
        private readonly RacerVehicleService _racerVehicleService;
        public RacerVehicleController(RacerVehicleService racerVehicleService)
        {
            _racerVehicleService = racerVehicleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<RacerVehicle> racerVehicles = _racerVehicleService.GetRacerVehicles();
            return View(racerVehicles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RacerVehicle racerVehicle)
        {
            if(ModelState.IsValid)
            {
                _racerVehicleService.CreateRacerVehicle(racerVehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(racerVehicle);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            RacerVehicle racerVehicle = _racerVehicleService.GetRacerVehicleById(id);
            if (racerVehicle == null)
            {
                return NotFound();
            }
            return View(racerVehicle);
        }
        [HttpPost]
        public IActionResult Edit(RacerVehicle racerVehicle)
        {
            if(ModelState.IsValid)
            {
                _racerVehicleService.UpdateRacerVehicle(racerVehicle);
                return RedirectToAction("Index");
            }
            return View(racerVehicle);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _racerVehicleService.DeleteRacerVehicle(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Intergalactic_Race_League.Controllers
{
    public class RacerVehicleController : Controller
    {
        private readonly RacerVehicleService _racerVehicleService;
        private readonly RacerService _racerService;
        private readonly VehicleService _vehicleService;
        private readonly ILogger<RacerVehicleController> _logger;

        public RacerVehicleController(RacerVehicleService racerVehicleService, RacerService racerService, VehicleService vehicleService, ILogger<RacerVehicleController> logger)
        {
            _racerVehicleService = racerVehicleService;
            _racerService = racerService;
            _vehicleService = vehicleService;
            _logger = logger;
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
            var racers = _racerService.GetRacers();
            var vehicles = _vehicleService.GetVehicles();
            ViewBag.Racers = new SelectList(racers, "RacerId", "DriverName");
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Model");
            return View();
        }

        [HttpPost]
        public IActionResult Create(RacerVehicle racerVehicle)
        {
            if (ModelState.IsValid)
            {
                _racerVehicleService.CreateRacerVehicle(racerVehicle);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.LogError(error.ErrorMessage);
            }
            var racers = _racerService.GetRacers();
            var vehicles = _vehicleService.GetVehicles();
            ViewBag.Racers = new SelectList(racers, "RacerId", "DriverName");
            ViewBag.Vehicles = new SelectList(vehicles, "VehicleId", "Model");
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

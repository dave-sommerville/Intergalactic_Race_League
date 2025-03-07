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
                Racer racer = new Racer
                {
                    DriverName = racerVehicle.Racer.DriverName,
                    DriverHeightInCm = racerVehicle.Racer.DriverHeightInCm
                };
                
            }
            return View(racerVehicle);
        }

    }
}

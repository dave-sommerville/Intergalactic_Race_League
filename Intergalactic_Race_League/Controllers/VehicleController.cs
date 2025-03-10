using Microsoft.AspNetCore.Mvc;
using Intergalactic_Race_League.BLL;
using Intergalactic_Race_League.Models;

namespace Intergalactic_Race_League.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;
        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _vehicleService.GetVehicles();
            return View(vehicles);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
    }
}

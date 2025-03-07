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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle newVehicle = new Vehicle
                {
                    Model = vehicle.Model,
                    Type = vehicle.Type
                };
                _vehicleService.AddVehicle(newVehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if(ModelState.IsValid)
            {
                return View(vehicle);
            }
            _vehicleService.UpdateVehicle(vehicle);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _vehicleService.DeleteVehicle(id);
            return RedirectToAction("Index");
        }
    }
}

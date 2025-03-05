using Microsoft.AspNetCore.Mvc;

namespace Intergalactic_Race_League.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

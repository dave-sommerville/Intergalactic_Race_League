using Microsoft.AspNetCore.Mvc;

namespace Intergalactic_Race_League.Controllers
{
    public class RacerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

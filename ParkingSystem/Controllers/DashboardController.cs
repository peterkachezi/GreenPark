using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

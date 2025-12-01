using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class StaticsbarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

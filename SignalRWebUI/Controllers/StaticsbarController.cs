using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class StaticsbarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

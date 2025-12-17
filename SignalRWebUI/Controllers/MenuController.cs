using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet("Menu/Index/{Masa}")]
        public IActionResult Index(string Masa)
        {
            ViewBag.VMasa = Masa;
            return View();
        }
    }
}

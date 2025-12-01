using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class StaticsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}

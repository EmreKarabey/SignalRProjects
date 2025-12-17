using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}

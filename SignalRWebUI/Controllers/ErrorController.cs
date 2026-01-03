using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ErrorController : Controller
    {
        
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}

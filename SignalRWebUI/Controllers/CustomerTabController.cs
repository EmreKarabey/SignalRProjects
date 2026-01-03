using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTable;

namespace SignalRWebUI.Controllers
{
    public class CustomerTabController : Controller
    {

        public IActionResult Index()
        {
          
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents
{
    public class _HomePageNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

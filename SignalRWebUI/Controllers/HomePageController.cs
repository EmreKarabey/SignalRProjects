using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Message;

namespace SignalRWebUI.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomePageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        public async Task<IActionResult> SendMessageIA(SendMessage sendMessage)
        {
            var client = _httpClientFactory.CreateClient();

            var JsonFile = JsonConvert.SerializeObject(sendMessage);

            var stringContent = new StringContent(JsonFile,System.Text.Encoding.UTF8,"application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Message",stringContent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index");
           

        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Contact;
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
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage2 = await client.GetAsync("https://localhost:7042/api/Contact");

            if (!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile2 = await responsemessage2.Content.ReadAsStringAsync();

            var file2 = JsonConvert.DeserializeObject<List<ContactList>>(jsonfile2).FirstOrDefault();

            ViewBag.Map = file2.Location;

            return View();
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        public async Task<IActionResult> SendMessageIA(SendMessage sendMessage)
        {
            if (!ModelState.IsValid) return View("Index");

            var client = _httpClientFactory.CreateClient();

            var JsonFile = JsonConvert.SerializeObject(sendMessage);

            var stringContent = new StringContent(JsonFile, System.Text.Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Message", stringContent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index");


        }

    }
}

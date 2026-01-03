using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Contact;
using SignalRWebUI.Dtos.Notification;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.GetAsync("https://localhost:7042/api/Notification");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<List<NotificationList>>(jsonfile);

            return View(file);
        }

       
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Notification/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRead(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Notification/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var stringcontent = new StringContent(jsonfile,Encoding.UTF8,"application/json");

            var responsemessage2 = await client.PutAsync("https://localhost:7042/api/Notification/UpdateRead", stringcontent);

            if (!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index");


        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotRead(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Notification/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage2 = await client.PutAsync("https://localhost:7042/api/Notification/UpdateNotRead", stringcontent);

            if (!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index");


        }
    }
}

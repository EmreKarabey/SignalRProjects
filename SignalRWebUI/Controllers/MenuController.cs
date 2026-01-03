using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTable;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/MenuTables/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<MenuTableList>(jsonfile);

            file.Status = false;

            ViewBag.VID = file.MenuTableID;

            var jsonfile2 = JsonConvert.SerializeObject(file);

            var stringcontent = new StringContent(jsonfile2,System.Text.Encoding.UTF8,"application/json");

            var responsemessage2 = await client.PutAsync("https://localhost:7042/api/MenuTables",stringcontent);

            if(!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return View();
        }
    }
}

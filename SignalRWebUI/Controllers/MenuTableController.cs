using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Category;
using SignalRWebUI.Dtos.MenuTable;

namespace SignalRWebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public MenuTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MenuTableList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/MenuTables");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<MenuTableList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/MenuTables/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("MenuTableList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/MenuTables/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateMenuTable>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTable updateMenuTable)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateMenuTable);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/MenuTables", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("MenuTableList");
        }
        [HttpGet]
        public IActionResult AddMenuTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuTable(AddMenuTable addMenuTable)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addMenuTable);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/MenuTables", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("MenuTableList");
        }

        public IActionResult TableOccupancyRate()
        {
            return View();
        }
    }
}

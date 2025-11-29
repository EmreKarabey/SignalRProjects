using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Feature;

namespace SignalRWebUI.Controllers
{
    public class FeatureController : Controller
    {
        public IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Feature");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<FeatureList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Feature/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Feature/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateFeature>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeature updateFeature)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateFeature);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/Feature", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature(AddFeature addFeature)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addFeature);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Feature", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("FeatureList");
        }


    }
}

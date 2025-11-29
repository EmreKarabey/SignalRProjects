using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.SocialMedia;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        public IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> SocialMediaList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/SocialMedia");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<SocialMediaList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/SocialMedia/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/SocialMedia/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateSocialMedia>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMedia updateSocial)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateSocial);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/SocialMedia", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(AddSocialMedia addSocialMedia)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addSocialMedia);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/SocialMedia", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("SocialMediaList");
        }
    }
}

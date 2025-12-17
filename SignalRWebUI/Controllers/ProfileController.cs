using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AppUser;

namespace SignalRWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Auth/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateAppUser>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateAppUser updateApp)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateApp);

            var stringcontent = new StringContent(jsonfile,System.Text.Encoding.UTF8,"application/json");

            var responsemessage =await client.PutAsync("https://localhost:7042/api/Auth/UpdateProfile", stringcontent);

            if(!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Index","Statics");
        }
    }
}

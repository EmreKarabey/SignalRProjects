using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AppUser;

namespace SignalRWebUI.ViewComponents
{
    public class _AdminNavbarPageComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminNavbarPageComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserID = HttpContext.Session.GetInt32("UserId");
            var client = _httpClientFactory.CreateClient();

            var responsemssage = await client.GetAsync($"https://localhost:7042/api/Auth/{UserID}");

            if (
                responsemssage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemssage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<AppUserList>(jsonfile);

                ViewBag.Image = "https://localhost:7042/Image/UserImage/" + file.ImageURL;

                return View(file);
            }
            return View();
        }
    }
}

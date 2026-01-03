using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AppUser;

namespace SignalRWebUI.ViewComponents
{
    public class _AdminPageUserComponents : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminPageUserComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var UserID = HttpContext.Session.GetInt32("UserId");
            var client = _httpClientFactory.CreateClient();

            var responsmessage = await client.GetAsync($"https://localhost:7042/api/Auth/{UserID}");

            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsmessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<AppUserList>(jsonfile);

                ViewBag.VName = file.Name + " " + file.Surname;

                ViewBag.Image = "https://localhost:7042/Image/UserImage/" + file.ImageURL;
            }

            return View();
        }
    }
}

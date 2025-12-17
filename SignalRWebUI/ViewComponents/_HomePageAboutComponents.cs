using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.About;

namespace SignalRWebUI.ViewComponents
{
    public class _HomePageAboutComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageAboutComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.GetAsync("https://localhost:7042/api/About/1");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<AboutList>(jsonfile);

                return View(file);
            }
            return View();
        }
    }
}

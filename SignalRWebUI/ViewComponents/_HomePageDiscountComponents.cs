using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Discount;

namespace SignalRWebUI.ViewComponents
{
    public class _HomePageDiscountComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageDiscountComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.GetAsync("https://localhost:7042/api/Discount");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<DiscountList>>(jsonfile);

                return View(file);
            }
            return View();
        }
    }
}

using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.ViewComponents
{
    public class _CategoryViewComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CategoryViewComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Category");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<Category>>(jsonfile);

                return View(file);
            }
            return View();
        }
    }
}

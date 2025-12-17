using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Testimonial;

namespace SignalRWebUI.ViewComponents
{
    public class _HomePageTestimonialComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageTestimonialComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.GetAsync("https://localhost:7042/api/Testimonial");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfle = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<TestimonialList>>(jsonfle);

                return View(file);
            }
            return View();
        }
    }
}

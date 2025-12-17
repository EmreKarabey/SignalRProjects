using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Contact;

namespace SignalRWebUI.ViewComponents
{
    public class _ContactWebUIComponents:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactWebUIComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.GetAsync("https://localhost:7042/api/Contact/3");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<ContactList>(jsonfile);

                return View(file);
            }
            return View();
        }
    }
}

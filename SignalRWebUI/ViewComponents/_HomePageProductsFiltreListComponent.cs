using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Products;

namespace SignalRWebUI.ViewComponents
{
    public class _HomePageProductsFiltreListComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageProductsFiltreListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
         
            var client = _httpClientFactory.CreateClient();

            var resposemessage = await client.GetAsync("https://localhost:7042/api/Products");

            if (resposemessage.IsSuccessStatusCode)
            {
                var jsonfile = await resposemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<ProductsListDto>>(jsonfile);



                return View(file);
            }
            return View();
        }
    }
}

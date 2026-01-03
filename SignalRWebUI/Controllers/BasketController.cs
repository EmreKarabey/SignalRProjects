using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Basket;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.MenuTable;
using SignalRWebUI.Dtos.Products;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        public IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> BasketList(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Basket/{id}");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<BasketsList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int quantity,int menutable)
        {
            var clients = _httpClientFactory.CreateClient();
            var responsemessage = await clients.GetAsync($"https://localhost:7042/api/Products/{id}");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<ProductsListDto>(jsonfile);

                var addbasket = new AddBasket()
                {
                    Count = quantity,
                    UnitPrice = file.Price,
                    MenuTableID = menutable,
                    ProductsID = file.ProductsID,
                    TotalPrice = file.Price * quantity

                };
                var jsonfile2 = JsonConvert.SerializeObject(addbasket);

                var stringcontent = new StringContent(jsonfile2, Encoding.UTF8, "application/json");

                var responsemessage2 = await clients.PostAsync("https://localhost:7042/api/Basket", stringcontent);

                if (responsemessage2.IsSuccessStatusCode)
                {
                    var responsemsaage = await responsemessage2.Content.ReadAsStringAsync();
                    return RedirectToAction("BasketList", new { id = menutable });
                }
            }

            return View();


        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var clients = _httpClientFactory.CreateClient();

            var responsemessage = await clients.DeleteAsync($"https://localhost:7042/api/Basket/{id}");

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BasketList");
            }
            return View();
        }

    }
}

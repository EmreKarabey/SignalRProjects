using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Basket;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.MenuTable;
using SignalRWebUI.Dtos.Products;

namespace SignalRWebUI.Controllers
{
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
        public async Task<IActionResult> AddBasket(int id, int quantity, string masano)
        {



            var clients = _httpClientFactory.CreateClient();


            if (masano == null) RedirectToAction("ErrorPage", "Error");

            var responsemessage3 = await clients.GetAsync($"https://localhost:7042/api/MenuTables/{masano}");

            if (!responsemessage3.IsSuccessStatusCode) return RedirectToAction();

            var jsonfile3 = await responsemessage3.Content.ReadAsStringAsync();

            var file3 = JsonConvert.DeserializeObject<MenuTableList>(jsonfile3);

            if (file3.Status == false) return RedirectToAction("ErrorPage", "Error");


            var responsemessage = await clients.GetAsync($"https://localhost:7042/api/Products/{id}");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<ProductsListDto>(jsonfile);

                var addbasket = new AddBasket()
                {
                    Count = quantity,
                    UnitPrice = file.Price,
                    MenuTableID = file3.MenuTableID,
                    ProductsID = file.ProductsID,
                    TotalPrice = file.Price * quantity

                };
                var jsonfile2 = JsonConvert.SerializeObject(addbasket);

                var stringcontent = new StringContent(jsonfile2, Encoding.UTF8, "application/json");

                var responsemessage2 = await clients.PostAsync("https://localhost:7042/api/Basket", stringcontent);

                if (responsemessage2.IsSuccessStatusCode)
                {
                    var responsemsaage = await responsemessage2.Content.ReadAsStringAsync();
                    return RedirectToAction("BasketList", new { id = file3.MenuTableID });
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

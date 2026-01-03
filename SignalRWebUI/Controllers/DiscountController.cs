using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Category;
using SignalRWebUI.Dtos.Discount;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> DiscountList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Discount");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<DiscountList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Discount/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("DiscountList");
        }

     

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Discount/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateDiscount>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscount updateDiscount)
        {
            var client = _httpClientFactory.CreateClient();

            var file = new MultipartFormDataContent();

            file.Add(new StringContent(updateDiscount.DiscountID.ToString()), "DiscountID");
            file.Add(new StringContent(updateDiscount.Title.ToString()), "Title");
            file.Add(new StringContent(updateDiscount.Amount.ToString()), "Amount");
            file.Add(new StringContent(updateDiscount.Description.ToString()), "Description");

            if (updateDiscount.Image != null)
            {
                var stream = updateDiscount.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                file.Add(filecontent,"Image",updateDiscount.Image.FileName);
            }

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/Discount", file);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("DiscountList");
        }

        [HttpGet]
        public IActionResult AddDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscount(AddDiscount addDiscount)
        {
            var client = _httpClientFactory.CreateClient();

            var file = new MultipartFormDataContent();

            file.Add(new StringContent(addDiscount.Title), "Title");
            file.Add(new StringContent(addDiscount.Amount), "Amount");
            file.Add(new StringContent(addDiscount.Description), "Description");

            if (addDiscount.Image != null)
            {
                var stream = addDiscount.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                file.Add(filecontent,"Image",addDiscount.Image.FileName);
            }

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Discount", file);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("DiscountList");
        }

    }
}

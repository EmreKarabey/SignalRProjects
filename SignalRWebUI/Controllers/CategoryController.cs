using System.Net.Http;
using System.Text;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Category;
using SignalRWebUI.Dtos.Products;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Category");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<CategoryList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Category/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Category/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateCategory>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategory updateCategory)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateCategory);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/Category", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategory addCategory)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addCategory);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Category", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("CategoryList");
        }

    }
}

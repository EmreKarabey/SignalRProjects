using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Products;

namespace SignalRWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> ProductsList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Products");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<ProductsListDto>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Products/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ProductsList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProducts(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Products/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateProducts>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProducts updateProducts)
        {
            var client = _httpClientFactory.CreateClient();

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(updateProducts.ProductsID.ToString()), "ProductsID");
            form.Add(new StringContent(updateProducts.ProductsName.ToString()), "ProductsName");
            form.Add(new StringContent(updateProducts.Description.ToString()), "Description");
            form.Add(new StringContent(updateProducts.Price.ToString()), "Price");
            form.Add(new StringContent(updateProducts.CategoryID.ToString()), "CategoryID");

            if (updateProducts.Image != null)
            {
                var stream = updateProducts.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                form.Add(filecontent, "Image", updateProducts.Image.FileName);
            }

            var responsemessage = await client.PutAsync("https://localhost:7042/api/Products", form);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ProductsList");


        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProduct addProduct)
        {
            var client = _httpClientFactory.CreateClient();

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(addProduct.ProductsName), "ProductsName");
            form.Add(new StringContent(addProduct.Description), "Description");
            form.Add(new StringContent(addProduct.Price.ToString()), "Price");
            form.Add(new StringContent(addProduct.CategoryID.ToString()), "CategoryId");

            if (addProduct.Image != null)
            {
                var stream = addProduct.Image.OpenReadStream();
                var fileContent = new StreamContent(stream);

                form.Add(fileContent, "Image", addProduct.Image.FileName);
            }

            var response = await client.PostAsync("https://localhost:7042/api/Products", form);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ProductsList");
        }

    }
}

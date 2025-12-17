using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.About;
using SignalRWebUI.Dtos.Categories;

namespace SignalRWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/About");

            if(!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<List<AboutList>>(jsonfile);

            return View(file);
        }


        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(AddAbout addAbout)
        {
            var client = _httpClientFactory.CreateClient();

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(addAbout.Title), "Title");
            form.Add(new StringContent(addAbout.Description), "Description");

            if (addAbout.Image != null)
            {
                var stream = addAbout.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                form.Add(filecontent, "Image", addAbout.Image.FileName);
            }

            var responsemessage = await client.PostAsync("https://localhost:7042/api/About", form);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("AboutList");
        }



        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/About/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateAbout>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAbout updateAbout)
        {
            var client = _httpClientFactory.CreateClient();

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(updateAbout.AboutID.ToString()), "AboutID");
            form.Add(new StringContent(updateAbout.Title.ToString()), "Title");
            form.Add(new StringContent(updateAbout.Description.ToString()), "Description");

            if (updateAbout.Image != null)
            {
                var stream = updateAbout.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                form.Add(filecontent, "Image", updateAbout.Image.FileName);
            }

            var responsemessage = await client.PutAsync("https://localhost:7042/api/About",form);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("AboutList");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/About/{id}");

            if(!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("AboutList");
        }
    }
}

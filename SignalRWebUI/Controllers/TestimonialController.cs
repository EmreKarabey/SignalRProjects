using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.About;
using SignalRWebUI.Dtos.Products;
using SignalRWebUI.Dtos.Testimonial;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> TestimonialList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Testimonial");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<TestimonialList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Testimonial/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Testimonial/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateTestimonial>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonial updateTestimonial)
        {
            var client = _httpClientFactory.CreateClient();

            var form = new MultipartFormDataContent();

            form.Add(new StringContent(updateTestimonial.TestimonialID.ToString()), "TestimonialID");
            form.Add(new StringContent(updateTestimonial.Name.ToString()), "Name");
            form.Add(new StringContent(updateTestimonial.Title.ToString()), "Title");
            form.Add(new StringContent(updateTestimonial.Comment.ToString()), "Comment");
            form.Add(new StringContent(updateTestimonial.Status.ToString()), "Status");

            if (updateTestimonial.Image != null)
            {
                var stream = updateTestimonial.Image.OpenReadStream();

                var filecontent = new StreamContent(stream);

                form.Add(filecontent, "Image", updateTestimonial.Image.FileName);
            }

            var responsemessage = await client.PutAsync("https://localhost:7042/api/Testimonial", form);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("TestimonialList");


        }
    }
}

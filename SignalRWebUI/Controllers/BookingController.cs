using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.Categories;
using SignalRWebUI.Dtos.Category;

namespace SignalRWebUI.Controllers
{
    [IgnoreAntiforgeryToken] // <-- B
    public class BookingController : Controller
    {
        public IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> BookingList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Booking");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<BookingList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Booking/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Booking/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateBooking>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBooking updateBooking)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateBooking);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/Booking", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("BookingList");
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBooking addBooking)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addBooking);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Booking", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("BookingList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCancel(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responnsemessage = await client.GetAsync($"https://localhost:7042/api/Booking/{id}");

            if(!responnsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responnsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateBooking>(jsonfile);

            var jsonfile2 = JsonConvert.SerializeObject(file);

            var stringcontent = new StringContent(jsonfile2,Encoding.UTF8,"application/json");

            var responsemessage2 = await client.PutAsync("https://localhost:7042/api/Booking/ChangeCancel", stringcontent);

            if(!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("BookingList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSuccess(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responnsemessage = await client.GetAsync($"https://localhost:7042/api/Booking/{id}");

            if (!responnsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responnsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateBooking>(jsonfile);

            var jsonfile2 = JsonConvert.SerializeObject(file);

            var stringcontent = new StringContent(jsonfile2, Encoding.UTF8, "application/json");

            var responsemessage2 = await client.PutAsync("https://localhost:7042/api/Booking/ChangeSuccess", stringcontent);

            if (!responsemessage2.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("BookingList");
        }


    }
}

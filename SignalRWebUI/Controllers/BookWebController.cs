using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Booking;

namespace SignalRWebUI.Controllers
{
    public class BookWebController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookWebController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddBooking addBooking)
        {
            var clients = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addBooking);

            var stringcontent = new StringContent(jsonfile,System.Text.Encoding.UTF8,"application/json");

            var responsemessage = await clients.PostAsync("https://localhost:7042/api/Booking",stringcontent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

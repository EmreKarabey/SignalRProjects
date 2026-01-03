using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.Booking;
using SignalRWebUI.Dtos.Contact;
using SignalRWebUI.Dtos.SocialMedia;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        public IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> ContactList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync("https://localhost:7042/api/Contact");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonfile = await responsemessage.Content.ReadAsStringAsync();

                var file = JsonConvert.DeserializeObject<List<ContactList>>(jsonfile);

                return View(file);
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.DeleteAsync($"https://localhost:7042/api/Contact/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ContactList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Contact/{id}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateContact>(jsonfile);

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContact updateContact)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(updateContact);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PutAsync($"https://localhost:7042/api/Contact", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContact addContact)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(addContact);

            var stringcontent = new StringContent(jsonfile, Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Contact", stringcontent);

            if (!responsemessage.IsSuccessStatusCode)
                return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("ContactList");
        }
    }
}

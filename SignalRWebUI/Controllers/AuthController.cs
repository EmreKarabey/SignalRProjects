using System.Security.Claims;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AppUser;

namespace SignalRWebUI.Controllers
{
    public class AuthController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(register);

            var stringcontent = new StringContent(jsonfile, System.Text.Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Auth", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonfile = JsonConvert.SerializeObject(login);

            var stringcontent = new StringContent(jsonfile, System.Text.Encoding.UTF8, "application/json");

            var responsemessage = await client.PostAsync("https://localhost:7042/api/Auth/Login", stringcontent);

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonData = await responsemessage.Content.ReadAsStringAsync();

            
            var result = JsonConvert.DeserializeObject<dynamic>(jsonData);

            // 3. ID'yi çek (API'den gönderdiğimiz 'Id' alanı)
            string userId = result.id.ToString();

            // 4. CLAIMS (Kimlik) Listesini Oluştur
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, login.Mail),
            
            // 👇 KRİTİK NOKTA: ID'yi buraya ekliyorsun
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

            // 5. Cookie Oluşturma (Standart kodlar)
            var useridentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Profile");
        }
    }
}

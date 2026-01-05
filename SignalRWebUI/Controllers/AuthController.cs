using System.Security.Claims;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.Win32;
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
        public async Task<IActionResult> Register([FromForm] RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                using (var form = new MultipartFormDataContent())
                {

                    if (register.Image != null)
                    {
                        var stream = register.Image.OpenReadStream();
                        var fileContent = new StreamContent(stream);

                        form.Add(fileContent, "Image", register.Image.FileName);
                    }


                    form.Add(new StringContent(register.Name ?? ""), "Name");
                    form.Add(new StringContent(register.PhoneNumber ?? ""), "PhoneNumber");
                    form.Add(new StringContent(register.Surname ?? ""), "Surname");
                    form.Add(new StringContent(register.Mail ?? ""), "Mail");
                    form.Add(new StringContent(register.UserName ?? ""), "UserName");
                    form.Add(new StringContent(register.Password ?? ""), "Password");
                    form.Add(new StringContent(register.Password ?? ""), "ConfirmPassword");


                    var response = await client.PostAsync("https://localhost:7042/api/Auth/Register", form);


                    if (!response.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

                    return RedirectToAction("Login");
                }

            }
            return View();
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

            if (responsemessage.IsSuccessStatusCode)
            {

                var jsonfile2 = await responsemessage.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<LogiinDto>(jsonfile2);


                var claims = new List<Claim>
        {

            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),


            new Claim(ClaimTypes.Name, user.Username ?? "Kullanıcı"),


        };


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Beni hatırla gibi çalışır, tarayıcı kapansa da tutar
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60) // 60 dakika oturum açık kalsın
                };


                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "QrCode");
            }

            return RedirectToAction("ErrorPage", "Error");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userid = HttpContext.Session.GetInt32("UserId");

            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Auth/{userid}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<AppUserList>(jsonfile);

            ViewBag.Image = "https://localhost:7042/Image/UserImage/" + file.ImageURL;


            return View(file);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var client = _httpClientFactory.CreateClient();

            var responsemessage = await client.GetAsync($"https://localhost:7042/api/Auth/{userid}");

            if (!responsemessage.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

            var jsonfile = await responsemessage.Content.ReadAsStringAsync();

            var file = JsonConvert.DeserializeObject<UpdateProfile>(jsonfile);

            ViewBag.Image = "https://localhost:7042/Image/UserImage/" + file.ImageURL;

            return View(file);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfile updateProfile)
        {
            var client = _httpClientFactory.CreateClient();

            using (var form = new MultipartFormDataContent())
            {
                if (updateProfile.Image != null)
                {
                    var stream = updateProfile.Image.OpenReadStream();
                    var fileContent = new StreamContent(stream);

                    form.Add(fileContent, "Image", updateProfile.Image.FileName);
                }


                form.Add(new StringContent(updateProfile.Id.ToString() ?? ""), "Id");
                form.Add(new StringContent(updateProfile.Name ?? ""), "Name");
                form.Add(new StringContent(updateProfile.Surname ?? ""), "Surname");
                form.Add(new StringContent(updateProfile.Email ?? ""), "Email");
                form.Add(new StringContent(updateProfile.Username ?? ""), "UserName");
                form.Add(new StringContent(updateProfile.Password ?? ""), "Password");
                form.Add(new StringContent(updateProfile.ConfirmPassword ?? ""), "ConfirmPassword");


                var response = await client.PutAsync("https://localhost:7042/api/Auth/UpdateProfile", form);


                if (!response.IsSuccessStatusCode) return RedirectToAction("ErrorPage", "Error");

                return RedirectToAction("GetProfile");
            }
        }


        public record LogiinDto()
        {
            public int Id { get; set; }
            public string Username { get; set; }
        }
    }
}

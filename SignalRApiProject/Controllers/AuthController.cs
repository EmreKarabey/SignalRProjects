using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.MicrosoftExtensions;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<ApiMessageResponse>> Register([FromBody] Addregister addregister)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            if (await _usermanager.FindByEmailAsync(addregister.Mail) is not null || await _usermanager.FindByNameAsync(addregister.UserName) is not null) return Conflict(new ApiMessageResponse("Eklemek İstediğiniz Hesap Zaten Mevcut"));

            var appuser = new AppUser
            {
                Name = addregister.Name,
                Surname = addregister.Surname,
                Email = addregister.Mail,
                UserName = addregister.UserName
            };

            var responsemessage = await _usermanager.CreateAsync(appuser, addregister.Password);

            if (!responsemessage.Succeeded) return BadRequest(responsemessage.Errors);

            return Ok(new ApiMessageResponse("Başarılı Bir Şekilde Kayıt Olundu"));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ApiMessageResponse>> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = await _usermanager.FindByEmailAsync(login.Mail);

            if (user == null) return Conflict(new ApiMessageResponse("Kayıtlı Kullanıcı Bulunamadı"));

            var responsemessage = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: true);

            if (!responsemessage.Succeeded) return Conflict(new ApiMessageResponse("Giriş Yapılamadı. Lütfen Şifrenizi Kontrol Ediniz"));
            return Ok(new
            {
                Message = "Başarılı Bir Şekilde Giriş Yapıldı",
                Id = user.Id,
                Username = user.UserName
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var user = await _usermanager.FindByIdAsync(id.ToString());

            if (user == null) return NotFound();

            return Ok(user);

        }

        [HttpPut("UpdateProfile")]
        public async Task<ActionResult<ApiMessageResponse>> UpdateProfile(UpdateUser updateUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = await _usermanager.FindByEmailAsync(updateUser.EMail);

            user.Name = updateUser.Name;
            user.Surname = updateUser.Surname;
            user.UserName = updateUser.UserName;
            user.Email = updateUser.EMail;


            if (updateUser.Password != null) user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, updateUser.Password);

            var results = await _usermanager.UpdateAsync(user);

            if (results.Succeeded) return Ok("Başarılı Bir Şekilde Güncellendi");

            return Ok(new ApiMessageResponse("Güncellemede Bir Sorun Yaşandı"));

        }


        public record Addregister
        {
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen İsim Giriniz")] public string Name { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Soyisim Giriniz")] public string Surname { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Mail Giriniz")] public string Mail { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string UserName { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz"), MinLength(6, ErrorMessage = "Lütfen En Az 6 Karakter Giriniz")] public string Password { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Tekrardan Giriniz"), MinLength(6, ErrorMessage = "Lütfen En Az 6 Karakter Giriniz"), Compare("Password", ErrorMessage = "Lütfen Aynı Şifreyi Tekrar Girin")] public string ConfirmPassword { get; set; }

        }

        public record UpdateUser
        {
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen İsim Giriniz")] public int Id { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen İsim Giriniz")] public string Name { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Soyisim Giriniz")] public string Surname { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Mail Giriniz")] public string EMail { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string UserName { get; set; }
             public string? Password { get; set; }
            [Compare("Password", ErrorMessage = "Lütfen Aynı Şifreyi Tekrar Girin")] public string? ConfirmPassword { get; set; }


        }

        public record LoginDto
        {
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string Mail { get; set; }
            [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz")] public string Password { get; set; }
        }

        public record ApiMessageResponse(string Message);
    }
}

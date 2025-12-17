using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.AppUser
{
    public class RegisterDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen İsim Giriniz")] public string? Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Soyisim Giriniz")] public string? Surname { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Mail Giriniz")] public string? Mail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string? UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz"), MinLength(6, ErrorMessage = "Lütfen En Az 6 Karakter Giriniz")] public string? Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Tekrardan Giriniz"), MinLength(6, ErrorMessage = "Lütfen En Az 6 Karakter Giriniz"), Compare("Password", ErrorMessage = "Lütfen Aynı Şifreyi Tekrar Girin")] public string? ConfirmPassword { get; set; }


    }
}

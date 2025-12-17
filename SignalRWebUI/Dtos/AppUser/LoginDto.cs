namespace SignalRWebUI.Dtos.AppUser
{
    public class LoginDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string Mail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz")] public string Password { get; set; }
    }
}

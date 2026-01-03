namespace SignalRWebUI.Dtos.AppUser
{
    public class LoginDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz")] public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

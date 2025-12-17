namespace SignalRWebUI.Views.Auth
{
    public class Login
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")] public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz")] public string Password { get; set; }
    }
}

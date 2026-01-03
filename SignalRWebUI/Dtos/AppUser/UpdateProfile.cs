using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.AppUser
{
    public class UpdateProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
         public string Username { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler Aynı Olmak Zorunda")] public string? ConfirmPassword { get; set; }
        public string? ImageURL { get; set; }
        public IFormFile? Image { get; set; }
    }
}

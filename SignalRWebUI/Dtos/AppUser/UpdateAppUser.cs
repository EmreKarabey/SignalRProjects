using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.AppUser
{
    public class UpdateAppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}

using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.Message;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class AdminMessageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminSendMessage adminSendMessage)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress Gönderen = new MailboxAddress("Admin","emrekarabey229@gmail.com");
            message.From.Add(Gönderen);

            MailboxAddress Alıcı = new MailboxAddress("User",adminSendMessage.ReceiveMail);
            message.To.Add(Alıcı);

            var body = new BodyBuilder();

            body.TextBody = adminSendMessage.Description;

            message.Body = body.ToMessageBody();

            message.Subject = adminSendMessage.Subject;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Connect("smtp.gmail.com", 465, true);

            smtpClient.Authenticate("emrekarabey229@gmail.com","qfvhmjkipzecardq");

            smtpClient.Send(message);

            smtpClient.Disconnect(true);

            return RedirectToAction("Index");

           
        }
    }
}

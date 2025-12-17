using System.ComponentModel.DataAnnotations;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageServices _messageServices;

        public MessageController(IMessageServices messageServices)
        {
            _messageServices = messageServices;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list = _messageServices.GetList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _messageServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult AddMessage(AddMessageDto messageDto)
        {
            var message = new Message
            {
                Name = messageDto.Name,
                Mail = messageDto.Mail,
                Phone = messageDto.Phone,
                Subject = messageDto.Subject,
                MessageContent = messageDto.MessageContent,
                Status = false,
                MessageDate = DateTime.Now
            };

            _messageServices.Add(message);

            return Ok("Başarılı Bir Şekilde Mesaj Gönderildi");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var entiy = _messageServices.GetById(id);

            if (entiy == null) return NotFound();

            _messageServices.Delete(entiy);

            return Ok("Başarılı Bir Şekilde Mesaj Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = new Message
            {
                MessageId = updateMessageDto.MessageId,
                Name = updateMessageDto.Name,
                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageDate = updateMessageDto.MessageDate,
                Status = updateMessageDto.Status
            };

            _messageServices.Update(message);

            return Ok("Başarılı Bir Şekilde Mesaj Güncellendi");
        }

        public record AddMessageDto
        {
            [Required(ErrorMessage = "Lütfen İsim Girin")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lüten Telefon Numarası Girin")] public string? Phone { get; set; }
            [Required(ErrorMessage = "Lüten Konu Girin")] public string? Subject { get; set; }
            [Required(ErrorMessage = "Lüten Açıklama Girin")] public string? MessageContent { get; set; }
            public DateTime MessageDate { get; set; }
            public bool Status { get; set; }
        }

        public record UpdateMessageDto
        {
            public int MessageId { get; set; }
            [Required(ErrorMessage = "Lütfen İsim Girin")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lüten Telefon Numarası Girin")] public string? Phone { get; set; }
            [Required(ErrorMessage = "Lüten Konu Girin")] public string? Subject { get; set; }
            [Required(ErrorMessage = "Lüten Açıklama Girin")] public string? MessageContent { get; set; }
            public DateTime MessageDate { get; set; }
            public bool Status { get; set; }
        }
    }
}

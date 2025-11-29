using System.ComponentModel.DataAnnotations;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public IContactServices _scontactServices;

        public ContactController(IContactServices contactServices)
        {
            _scontactServices = contactServices;
        }


        [HttpGet]
        public IActionResult ContactView()
        {
            var list = _scontactServices.GetList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _scontactServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }


        [HttpPost]
        public IActionResult AddContact(AddContactDto addContactDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var contact = new Contact()
            {
                Location = addContactDto.Location,
                Mail = addContactDto.Mail,
                Phone = addContactDto.Phone,
                FooterDescription = addContactDto.FooterDescription
            };

            _scontactServices.Add(contact);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var entity = _scontactServices.GetById(id);

            if (entity == null) return NotFound();

            _scontactServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _scontactServices.Update(contact);

            return Ok("Başarılı Bir Şekilde Güncellendi");

        }



        public record AddContactDto
        {
            [Required(ErrorMessage = "Lütfen Yer Girin")] public string? Location { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lütfen Telefon Girin")] public string? Phone { get; set; }
            public string? FooterDescription { get; set; }
        }
    }
}

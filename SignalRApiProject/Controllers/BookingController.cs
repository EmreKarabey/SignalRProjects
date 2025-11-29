using System.ComponentModel.DataAnnotations;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices _bookingServices;

        public BookingController(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }
        [HttpGet]
        public IActionResult GetAboutList()
        {
            var list = _bookingServices.GetList();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddBooking(AddBookingDto addbooking)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var booking = new Booking()
            {
                Name = addbooking.Name,
                Mail = addbooking.Mail,
                Phone = addbooking.Phone,
                PersonCount = (int)addbooking.PersonCount,
                Date =(DateTime) addbooking.Date

            };

            _bookingServices.Add(booking);

            return Ok("Başarılı Bir Şekilde Eklenildi");
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _bookingServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var entity = _bookingServices.GetById(id);

            if (entity == null) return NotFound();

            _bookingServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingServices.Update(booking);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        public record AddBookingDto
        {
            [Required(ErrorMessage = "Lütfen İsim Girin")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Telefon Numarası Girin")] public string? Phone { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lütfen Kişi Sayısı Girin")] public int? PersonCount { get; set; }
            [Required(ErrorMessage = "Lütfen Tarih Girin")] public DateTime? Date { get; set; }
        }

   
    }
}

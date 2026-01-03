using System.ComponentModel.DataAnnotations;
using AutoMapper;
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
        private readonly IMapper _mapper;


        public BookingController(IBookingServices bookingServices, IMapper mapper)
        {
            _bookingServices = bookingServices;
            _mapper = mapper;
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

            var values = _mapper.Map<Booking>(addbooking);

            _bookingServices.Add(values);

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
        public IActionResult UpdateBooking(UpdateBookingDto booking)
        {
            var entity = _bookingServices.GetById(booking.BookingID);

            if (entity == null) return NotFound();

            entity.Phone = booking.Phone;
            entity.Status = booking.Status;
            entity.Date = (DateTime)booking.Date;
            entity.BookingID = booking.BookingID;
            entity.Name = booking.Name;
            entity.PersonCount = (int)booking.PersonCount;

            _bookingServices.Update(entity);
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpPut("ChangeSuccess")]
        public IActionResult ChangeSuccess(UpdateBookingDto updateBookingDto)
        {
            var booking = _bookingServices.GetById(updateBookingDto.BookingID);

            booking.Status = "Rezervasyon Onaylandı";

            _bookingServices.ChangeSuccess(booking);

            return Ok("Başarılı Bir Şekilde Durum Güncellendi");
        }

        [HttpPut("ChangeCancel")]
        public IActionResult ChangeCancel(UpdateBookingDto updateBookingDto)
        {

            var booking = _bookingServices.GetById(updateBookingDto.BookingID);

            booking.Status = "Rezervasyon İptal Edildi";
            _bookingServices.ChangeCancel(booking);

            return Ok("Başarılı Bir Şekilde Durum Güncellendi");
        }

        public record AddBookingDto
        {
            [Required(ErrorMessage = "Lütfen İsim Girin")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Telefon Numarası Girin")] public string? Phone { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lütfen Kişi Sayısı Girin")] public int? PersonCount { get; set; }
            [Required(ErrorMessage = "Lütfen Tarih Girin")] public DateTime? Date { get; set; }
        }

        public record UpdateBookingDto
        {
            public int BookingID { get; set; }
            [Required(ErrorMessage = "Lütfen İsim Girin")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Telefon Numarası Girin")] public string? Phone { get; set; }
            [Required(ErrorMessage = "Lütfen Mail Girin")] public string? Mail { get; set; }
            [Required(ErrorMessage = "Lütfen Kişi Sayısı Girin")] public int? PersonCount { get; set; }
            [Required(ErrorMessage = "Lütfen Tarih Girin")] public DateTime? Date { get; set; }
            public string Status { get; set; }
        }


    }
}

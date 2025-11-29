using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SignalRApiProject.Controllers.TestimonialController;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialServices _testimonialServices;

        public TestimonialController(ITestimonialServices testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }

        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var list = _testimonialServices.GetList();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestmonialDto addTestmonialDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var testimonial = new Testimonial()
            {
                Name = addTestmonialDto.Name,
                Comment = addTestmonialDto.Comment,
                Title = addTestmonialDto.Title,
                Status = true
            };

            if (addTestmonialDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(resource);

                var imagename = Guid.NewGuid() + extension;

                var savelocation = resource + "/Image/TestimonialImage/" + imagename;

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await addTestmonialDto.Image.CopyToAsync(stream);
                }

                testimonial.ImageURL = imagename;
            }

            _testimonialServices.Add(testimonial);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var entity = _testimonialServices.GetById(id);

            if (entity == null) return NotFound();

            _testimonialServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestmonialDto updateTestmonialDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var entity = _testimonialServices.GetById(updateTestmonialDto.TestimonialID);

            if (entity == null) return NotFound();

            entity.Name = updateTestmonialDto.Name;
            entity.Title = updateTestmonialDto.Title;
            entity.Comment = updateTestmonialDto.Comment;
            entity.Status = (bool)updateTestmonialDto.Status;

            if (updateTestmonialDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(resource);

                var imagename = Guid.NewGuid() + extension;

                var savelocation = resource + "/Image/TestimonialImage/" + imagename;

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await updateTestmonialDto.Image.CopyToAsync(stream);
                }

                entity.ImageURL = imagename;
            }

            _testimonialServices.Update(entity);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _testimonialServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }


        public record AddTestmonialDto
        {
            [Required(ErrorMessage = "Lütfen İsim Giriniz")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Başlık Giriniz")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Yorum Giriniz")] public string? Comment { get; set; }
            public IFormFile? Image { get; set; }
        }

        public record UpdateTestmonialDto
        {
            public int TestimonialID { get; set; }
            [Required(ErrorMessage = "Lütfen İsim Giriniz")] public string? Name { get; set; }
            [Required(ErrorMessage = "Lütfen Başlık Giriniz")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Yorum Giriniz")] public string? Comment { get; set; }
            public IFormFile? Image { get; set; }
            public bool? Status { get; set; }
        }
    }
}

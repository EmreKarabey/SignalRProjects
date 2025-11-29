using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutServices _aboutServices;

        public AboutController(IAboutServices aboutServices)
        {
            _aboutServices = aboutServices;
        }

        [HttpGet("{id}")]
        public IActionResult AboutView(int id)
        {
            var entity = _aboutServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddAbout([FromForm] AddAboutDto addAbout)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var about = new About
            {
                Title = addAbout.Title,
                Description = addAbout.Description,
            };

            if (addAbout.Image != null)
            {
                var Resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(addAbout.Image.FileName);

                var imagename = Guid.NewGuid() + extension;

                var savelocaiton = Resource + "/Image/AboutImage/" + imagename;

                using (var stream = new FileStream(savelocaiton, FileMode.Create))
                {
                    await addAbout.Image.CopyToAsync(stream);
                }
                ;

                about.ImageURL = imagename;
            }



            _aboutServices.Add(about);
            return Ok("Başarılı Bir Şekilde Eklenildi");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var entity = _aboutServices.GetById(id);

            if (entity == null) return NotFound();

            _aboutServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromForm] UpdateAboutDto updateAbout)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var entity = _aboutServices.GetById(updateAbout.Id);

            if (entity == null) return NotFound();

            entity.AboutID = updateAbout.Id;

            entity.Title = updateAbout.Title;

            entity.Description = updateAbout.Description;

            if (updateAbout.Image == null)
            {
                _aboutServices.Update(entity);
                return Ok("Başarılı Bir Şekilde Güncellenildi");
            }
            var Resource = Directory.GetCurrentDirectory();

            var extension = Path.GetExtension(updateAbout.Image.FileName);

            var imagename = Guid.NewGuid() + extension;

            var savelocaiton = Resource + "/Image/AboutImage/" + imagename;

            using (var stream = new FileStream(savelocaiton, FileMode.Create))
            {
                await updateAbout.Image.CopyToAsync(stream);
            }
            ;
            entity.ImageURL = imagename;

            _aboutServices.Update(entity);

            return Ok("Başarılı Bir Şekilde Güncellenildi");
        }

        public record AddAboutDto
        {
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? Image { get; set; }
        }

        public record UpdateAboutDto
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? Image { get; set; }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaServices _socialMediaServices;

        public SocialMediaController(ISocialMediaServices socialMediaServices)
        {
            _socialMediaServices = socialMediaServices;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var list = _socialMediaServices.GetList();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddSocialMedia(AddSocialMediaDto addSocialMediaDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var socialmedia = new SocialMedia()
            {
                Title = addSocialMediaDto.Title,
                Url = addSocialMediaDto.URL,
                Icon = addSocialMediaDto.Icon
            };

            _socialMediaServices.Add(socialmedia);

            return Ok("Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var entity = _socialMediaServices.GetById(id);
            if (entity == null) return NotFound();

            _socialMediaServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaServices.Update(socialMedia);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _socialMediaServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        public record AddSocialMediaDto
        {
            [Required(ErrorMessage = "Lütfen SosyalMedya İsmi Giriniz")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen SosyalMedya Bağlantınızı Giriniz")] public string? URL { get; set; }
            public string? Icon { get; set; }

        }
    }
}

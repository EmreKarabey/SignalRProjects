using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public AboutController(IAboutServices aboutServices, IMapper mapper)
        {
            _aboutServices = aboutServices;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var list = _aboutServices.GetList();

            return Ok(_mapper.Map<List<AboutListDto>>(list));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _aboutServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(_mapper.Map<AboutListDto>(entity));
        }



        [HttpPost]
        public async Task<IActionResult> AddAbout([FromForm] AddAboutDto addAbout)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

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
                addAbout.ImageURL = imagename;


            }
            var values = _mapper.Map<About>(addAbout);
            _aboutServices.Add(values);

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
            var aboutid = _aboutServices.GetById(updateAbout.Id);
            if (aboutid == null) return NotFound("Hakkımda Bulunamadı");


            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            if (updateAbout.Image == null)
            {
                aboutid.AboutID = updateAbout.Id;
                aboutid.Title = updateAbout.Title;
                aboutid.Description = updateAbout.Description;

                _mapper.Map(updateAbout, aboutid);

                _aboutServices.Update(aboutid);
                return Ok("Başarılı Bir Şekilde Güncellendi");
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

            aboutid.AboutID = updateAbout.Id;
            aboutid.ImageURL = imagename;
            aboutid.Title = updateAbout.Title;
            aboutid.Description = updateAbout.Description;

             _mapper.Map(updateAbout, aboutid);

            _aboutServices.Update(aboutid);

            return Ok("Başarılı Bir Şekilde Güncellenildi");
        }



        public record AddAboutDto
        {
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? Image { get; set; }
            public string? ImageURL { get; set; }
        }

        public record UpdateAboutDto
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? Image { get; set; }
        }

        public record AboutListDto
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureServices _featureServices;

        public FeatureController(IFeatureServices featureServices)
        {
            _featureServices = featureServices;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var list = _featureServices.GetList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _featureServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult AddFeature(AddFeatureDto addFeatureDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var feature = new Feature
            {
                Title = addFeatureDto.Title,
                Description = addFeatureDto.Description
            };
            _featureServices.Add(feature);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var entity = _featureServices.GetById(id);

            if (entity == null) return NotFound();

            _featureServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(Feature feature)
        {
            _featureServices.Update(feature);
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        public record AddFeatureDto
        {
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string Title { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string Description { get; set; }
        }
    }
}

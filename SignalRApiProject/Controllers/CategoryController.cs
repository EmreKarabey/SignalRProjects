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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        private readonly IMapper _mapper;
        public CategoryController(ICategoryServices categoryServices,IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var list = _categoryServices.GetList();

            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            addCategoryDto.CategoryStatus = true;

            var values = _mapper.Map<Category>(addCategoryDto);

            _categoryServices.Add(values);

            return Ok("Başarılı Bir Şekilde Kategori Eklenildi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _categoryServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var entity = _categoryServices.GetById(id);

            if (entity == null) return NotFound();

            _categoryServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryServices.Update(category);
            return Ok("Başarılı Bir Şekilde Güncellenildi");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var entity = _categoryServices.CategoryCount();
            return Ok(entity);
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var entity = _categoryServices.ActiveCategory();
            return Ok(entity);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var entity = _categoryServices.PassiveCategory();
            return Ok(entity);
        }

        public record AddCategoryDto
        {
            [Required(ErrorMessage = "Lütfen Kategori Adı Girin")] public string? CategoryName { get; set; }
            [Required(ErrorMessage = "Lütfen Kategori Adı Girin")] public bool? CategoryStatus { get; set; } = true;
        }
    }
}

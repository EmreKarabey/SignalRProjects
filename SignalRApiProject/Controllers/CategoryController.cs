using System.ComponentModel.DataAnnotations;
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
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
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

            var category = new Category()
            {
                CategoryName = addCategoryDto.CategoryName
            };


            category.CategoryStatus = true;

            _categoryServices.Add(category);

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

        public record AddCategoryDto
        {
            [Required(ErrorMessage = "Lütfen Kategori Adı Girin")] public string? CategoryName { get; set; }
        }
    }
}

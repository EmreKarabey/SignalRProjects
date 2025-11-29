using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SignalRApiProject.Controllers.ProductsController;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        [HttpGet]
        public IActionResult GetListProducts()
        {
            var list = _productsServices.WithCategoryList();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(AddProductsDto addProductsDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var products = new Products
            {
                ProductsName = addProductsDto.ProductsName,
                Description = addProductsDto.Description,
                Price = (decimal)addProductsDto.Price,
                ProductStatus = true,
                CategoryID = (int)addProductsDto.CategoryId

            };
            if (addProductsDto.Image != null)
            {
                var resourve = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(addProductsDto.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resourve + "/Image/ProductsImage/" + imagename;

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await addProductsDto.Image.CopyToAsync(stream);
                }

                products.ImageURL = imagename;

            }

            _productsServices.Add(products);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _productsServices.IncludeGetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(int id)
        {
            var entity = _productsServices.GetById(id);

            if (entity == null) return NotFound();

            _productsServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducts(UpdateProductsDto updateProductsDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var products = _productsServices.GetById(updateProductsDto.ProductsID);


            products.ProductsName = updateProductsDto.ProductsName;
            products.Description = updateProductsDto.Description;
            products.Price = (decimal)updateProductsDto.Price;
            products.CategoryID = (int)updateProductsDto.CategoryId;


            if (updateProductsDto.Image == null)
            {
                _productsServices.Update(products);

                return Ok("Başarılı Bir Şekilde Güncellendi");
            }

            var resourve = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(updateProductsDto.Image.FileName);
            var imagename = Guid.NewGuid() + extension;
            var savelocation = extension + "/Image/ProductsImage/" + imagename;

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                await updateProductsDto.Image.CopyToAsync(stream);
            }

            products.ImageURL = imagename;

            _productsServices.Update(products);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        public record AddProductsDto
        {
            [Required(ErrorMessage = "Lütfen Ürün Adı Girin")] public string? ProductsName { get; set; }
            [Required(ErrorMessage = "Lütfen Ürün Açıklaması Girin")] public string? Description { get; set; }
            [Required(ErrorMessage = "Lütfen Ürün Fiyatı Girin")] public decimal? Price { get; set; }
            [Required(ErrorMessage = "Lütfen Kategori Girin")] public int? CategoryId { get; set; }
            public IFormFile? Image { get; set; }

        }

        public record UpdateProductsDto
        {
            public int ProductsID { get; set; }
            [Required(ErrorMessage = "Lütfen Ürün Adı Girin")] public string? ProductsName { get; set; }
            [Required(ErrorMessage = "Lütfen Ürün Açıklaması Girin")] public string? Description { get; set; }
            [Required(ErrorMessage = "Lütfen Ürün Fiyatı Girin")] public decimal? Price { get; set; }
            [Required(ErrorMessage = "Lütfen Kategori Girin")] public int? CategoryId { get; set; }
            public bool? Status { get; set; }
            public IFormFile? Image { get; set; }

        }
    }
}

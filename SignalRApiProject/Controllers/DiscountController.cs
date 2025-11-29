using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static SignalRApiProject.Controllers.DiscountController;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;

        public DiscountController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var list = _discountServices.GetList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _discountServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscount(AddDiscountDto addDiscountDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var discount = new Discount()
            {
                Title = addDiscountDto.Title,
                Description = addDiscountDto.Description,
                Amount = addDiscountDto.Amount,
            };

            if (addDiscountDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(addDiscountDto.Image.FileName);

                var imagename = Guid.NewGuid() + extension;

                var savelocation = resource + "/Image/DiscountImage/" + imagename;

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await addDiscountDto.Image.CopyToAsync(stream);
                }

                discount.ImageURL = imagename;
            }


            _discountServices.Add(discount);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var discount = _discountServices.GetById(updateDiscountDto.DiscountID);


            discount.Title = updateDiscountDto.Title;
            discount.Description = updateDiscountDto.Description;
            discount.Amount = updateDiscountDto.Amount;


            if (updateDiscountDto.ImageURL == null)
            {
                _discountServices.Update(discount);

                return Ok("Başarılı Bir Şekilde Güncellendi");
            }

            var resource = Directory.GetCurrentDirectory();

            var extension = Path.GetExtension(updateDiscountDto.ImageURL.FileName);

            var imagename = Guid.NewGuid() + extension;

            var savelocation = resource + "/Image/DiscountImage/" + imagename;

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                await updateDiscountDto.ImageURL.CopyToAsync(stream);
            }

            discount.ImageURL = imagename;

            _discountServices.Update(discount);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var entity = _discountServices.GetById(id);

            if (entity == null) return NotFound();

            _discountServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        public record AddDiscountDto
        {
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Değer Girin")] public string? Amount { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? Image { get; set; }
        }

        public record UpdateDiscountDto
        {
            public int DiscountID { get; set; }
            [Required(ErrorMessage = "Lütfen Başlık Girin")] public string? Title { get; set; }
            [Required(ErrorMessage = "Lütfen Değer Girin")] public string? Amount { get; set; }
            [Required(ErrorMessage = "Lütfen Açıklama Girin")] public string? Description { get; set; }
            public IFormFile? ImageURL { get; set; }
        }
    }
}

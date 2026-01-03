using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiProject.Dto.Basket;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public IBasketServices _basketServices;
        private readonly IMapper _mapper;


        public BasketController(IBasketServices basketServices,IMapper mapper)
        {
            _basketServices = basketServices;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTableBasket(int id)
        {
            var list = _basketServices.GetMenuTableBasket(id);

            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasket createBasket)
        {
            var values = _mapper.Map<Basket>(createBasket);
            _basketServices.Add(values);

            return Ok("Başarılı Bir Şekilde Sipariş Eklenildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var entity = _basketServices.GetById(id);

            if (entity == null) return NotFound();

            _basketServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }
    }
}

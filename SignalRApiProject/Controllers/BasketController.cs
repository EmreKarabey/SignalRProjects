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

        public BasketController(IBasketServices basketServices)
        {
            _basketServices = basketServices;
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
            var basket = new Basket()
            {
                ProductsID = createBasket.ProductsID,
                MenuTableID = createBasket.MenuTableID,
                UnitPrice = createBasket.UnitPrice,
                TotalPrice = createBasket.UnitPrice * createBasket.Count,
                Count = createBasket.Count
            };
            _basketServices.Add(basket);

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

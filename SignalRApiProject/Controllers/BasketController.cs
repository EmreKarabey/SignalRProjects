using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using SignalRApiProject.Dto.Basket;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public IBasketServices _basketServices;
        public IMenuTablesServices _menuTables;
        private readonly IMapper _mapper;


        public BasketController(IBasketServices basketServices, IMapper mapper, IMenuTablesServices menuTables)
        {
            _basketServices = basketServices;
            _mapper = mapper;
            _menuTables = menuTables;
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

        [HttpDelete("DeleteBasketMenuTable{id:int}")]
        public IActionResult DeleteBasketMenuTable(int id)
        {
            var entity = _menuTables.GetById(id);

            var basketdelete = _basketServices.GetList().Where(n=>n.MenuTableID==entity.MenuTableID).ToList();

            _basketServices.DeleteBasketList(basketdelete);

            return Ok("Başarılı Bir Şekilde Silindi");

        }
    }
}

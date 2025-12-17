using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTablesServices _menuTablesServices;

        public MenuTablesController(IMenuTablesServices menuTablesServices)
        {
            _menuTablesServices = menuTablesServices;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var entity = _menuTablesServices.MenuTableCount();
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var list = _menuTablesServices.GetList();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddMenuTable(MenuTable menuTable)
        {
            menuTable.Status = true;
            _menuTablesServices.Add(menuTable);

            return Ok("Başarılı Bir Şekilde Eklenildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var entity = _menuTablesServices.GetById(id);

            if (entity == null) return NotFound();

            _menuTablesServices.Delete(entity);

            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(MenuTable menuTable)
        {
            _menuTablesServices.Update(menuTable);

            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var entity = _menuTablesServices.GetById(id);

            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpGet("{masano}")]
        public IActionResult GetByName(string masano)
        {
            var entity = _menuTablesServices.GetMenuMasaName(masano);

            if (entity == null) return NotFound();

            return Ok(entity);
        }
    }
}

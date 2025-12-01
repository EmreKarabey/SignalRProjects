using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTables _menuTables;

        public MenuTablesController(IMenuTables menuTables)
        {
            _menuTables = menuTables;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var entity = _menuTables.MenuTableCount();
            return Ok(entity);
        }
    }
}

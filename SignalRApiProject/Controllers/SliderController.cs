using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderServices _sliderServices;

        public SliderController(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list = _sliderServices.GetList();

            return Ok(list);
        }
    }
}

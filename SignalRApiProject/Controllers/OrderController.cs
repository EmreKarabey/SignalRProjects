using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("OrderCount")]
        public IActionResult OrderCount()
        {
            var entity = _orderService.OrderCount();

            return Ok(entity);
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var entity = _orderService.ActiveOrderCount();

            return Ok(entity);
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var entity = _orderService.LastOrderPrice();

            return Ok(entity);
        }

        [HttpGet("TodaySumCount")]
        public IActionResult TodaySumCount()
        {
            var entity = _orderService.TodaySumCase();

            return Ok(entity);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain.Dto;
using ProductDemo.Services.Services;

namespace ProductDemo.API.Controllers
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


        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto request)
        {
            await _orderService.AddOrderAsync(request);
            return Ok();
        }
    }
}

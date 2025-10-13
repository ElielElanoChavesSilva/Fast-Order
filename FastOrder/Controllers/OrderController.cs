using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    [Route("orders")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<CreatedResult> PostAsync(OrderDTO dto)
        {
            var id = await _orderService.PostOrderAsync(dto);
            return Created($"orders/{id}", id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetByIdAsync(long id)
        {
            return Ok(await _orderService.FindByIdAsync(id));
        }
    }
}

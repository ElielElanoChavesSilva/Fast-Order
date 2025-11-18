using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs.Order.ItemOrder;
using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{

    [Route("orders/{idOrder}/items")]
    public class ItemOrderController(IItemOrderService itemOrderService) : BaseController
    {
        [HttpPost]
        public async Task<CreatedResult> PostAsync(long orderId, ItemOrderPostDTO dto)
        {
            var id = await itemOrderService.PostItemOrderAsync(dto, orderId);
            return Created($"orders/{orderId}/items/{id}", id);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<ItemOrderResponseDTO>> GetByIdAsync(long itemId)
        {
            return Ok(await itemOrderService.FindByIdAsync(itemId));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemOrderResponseDTO>>> GetAllAsync()
        {
            return Ok(await itemOrderService.FindAllAsync());
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteAsync(long itemId)
        {
            itemOrderService.Delete(itemId);
            return NoContent();
        }
    }
}

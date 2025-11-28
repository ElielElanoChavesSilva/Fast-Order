using FastOrder.Application.DTOs.Order;

namespace FastOrder.Application.Contracts
{
    public interface IOrderService
    {
        Task<long> PostOrderAsync(OrderPostDTO orderDTO);
        Task<OrderDTO> FindByIdAsync(long id);
        Task<IEnumerable<OrderDTO>> FindAllAsync();
    }
}

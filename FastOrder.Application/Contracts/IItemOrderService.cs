using FastOrder.Application.DTOs.Order.ItemOrder;

namespace FastOrder.Application.Contracts
{
    public interface IItemOrderService
    {
        Task<long> PostItemOrderAsync(ItemOrderPostDTO itemOrder, long orderId);
        Task<ItemOrderResponseDTO> FindByIdAsync(long id);
        Task<IEnumerable<ItemOrderResponseDTO>> FindAllAsync();
        void Delete(long itemOrderId);
    }
}

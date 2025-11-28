using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs.Order.ItemOrder;
using FastOrder.Application.Mappers;
using FastOrder.Domain.Repositories;

namespace FastOrder.Application.Services
{
    public class ItemOrderService(
        IItemOrderRepository itemOrderRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository) : IItemOrderService
    {
        public async Task<long> PostItemOrderAsync(ItemOrderPostDTO itemOrder, long orderId)
        {
            if (!await productRepository.Exists(itemOrder.ProductId))
                throw new Exception($"Produto de Id: {itemOrder.ProductId} não existe");

            if (!await orderRepository.Exists(orderId))
                throw new Exception($"Pedido de Id: {orderId} não existe");

            var entity = await itemOrderRepository.Add(new()
            {
                ProductId = itemOrder.ProductId,
                OrderId = orderId,
                Price = itemOrder.Price,
                QtdProduct = itemOrder.QtdProduct
            });

            return entity.Id;
        }

        public async Task<ItemOrderResponseDTO> FindByIdAsync(long id)
        {
            var entity = await itemOrderRepository.FindById(id) ??
                         throw new Exception("Item não encontrado");

            return ItemOrderMapper.ToDTO(entity);
        }

        public async Task<IEnumerable<ItemOrderResponseDTO>> FindAllAsync()
        {
            var entities = await itemOrderRepository.FindAll();
            return ItemOrderMapper.ToListDTO(entities);
        }

        public void Delete(long itemOrderId)
        {
            itemOrderRepository.Delete(itemOrderId);
        }
    }
}

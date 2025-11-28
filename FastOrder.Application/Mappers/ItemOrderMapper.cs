using FastOrder.Application.DTOs.Order.ItemOrder;
using FastOrder.Domain.Entities;

namespace FastOrder.Application.Mappers
{
    public static class ItemOrderMapper
    {
        public static ItemOrderEntity ToEntity(ItemOrderPostDTO dto)
        {
            return new ()
            {
                ProductId = dto.ProductId,
                Price = dto.Price,
                QtdProduct = dto.QtdProduct
            };
        }

        public static ItemOrderResponseDTO ToDTO(ItemOrderEntity dto)
        {
            return new()
            {
                ProductId = dto.ProductId,
                OrderId = dto.OrderId,
                Price = dto.Price,
                QtdProduct = dto.QtdProduct
            };
        }

        public static IEnumerable<ItemOrderResponseDTO> ToListDTO(IEnumerable<ItemOrderEntity> entities)
        {
            return entities.Select(x => new ItemOrderResponseDTO()
            {
                OrderId = x.OrderId,
                Price = x.Price,
                QtdProduct = x.QtdProduct,
                ProductId = x.ProductId
            });
             
        }
    }
}

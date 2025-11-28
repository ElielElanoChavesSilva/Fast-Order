using FastOrder.Application.DTOs.Order;
using FastOrder.Domain.Entities;

namespace FastOrder.Application.Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEntity(OrderPostDTO dto)
        {
            return new()
            {
                TotalPrice = dto.TotalPrice
            };
        }

        public static OrderDTO ToDTO(OrderEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                TotalPrice = entity.TotalPrice,
                CreatedAt = entity.CreatedAt,
                UpdateAt = entity.UpdateAt,
                IdClient = entity.ClientEntity.Id
            };
        }

        public static IEnumerable<OrderDTO> ToListDTO(List<OrderEntity> entities)
        {
            return entities.Select(x => new OrderDTO()
            {
                Id = x.Id,
                UpdateAt = x.UpdateAt,
                IdClient = x.ClientEntity.Id,
                CreatedAt = x.CreatedAt,
                TotalPrice = x.TotalPrice
            });
        }
    }
}

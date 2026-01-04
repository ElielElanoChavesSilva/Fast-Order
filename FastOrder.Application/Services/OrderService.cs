using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs.Order;
using FastOrder.Application.Mappers;
using FastOrder.Application.Publishers;
using FastOrder.Domain.Repositories;

namespace FastOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly OrderEventPublisher _orderEventPublisher;

        public OrderService(
            IClientRepository clientRepository,
            IOrderRepository orderRepository,
            OrderEventPublisher orderEventPublisher)
        {
            _orderEventPublisher = orderEventPublisher;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
        }

        public async Task<long> PostOrderAsync(OrderPostDTO orderDTO)
        {
            var clientEntity = await _clientRepository.FindById(orderDTO.IdClient) ??
                               throw new Exception($"Cliente de Id: {orderDTO.IdClient} não encontrado");

            var orderEntity = OrderMapper.ToEntity(orderDTO);
            orderEntity.ClientEntity = clientEntity;
            orderEntity.CreatedAt = DateTime.Now;
            orderEntity.UpdateAt = DateTime.Now;

            orderEntity = await _orderRepository.Add(orderEntity);

            await _orderEventPublisher.PublishOrderCreatedAsync(new()
            {
                Id = orderEntity.Id,
                CreatedAt = orderEntity.CreatedAt,
                TotalPrice = orderEntity.TotalPrice,
                UpdateAt = orderEntity.UpdateAt
            });

            return orderEntity.Id;
        }

        public async Task<OrderDTO?> FindByIdAsync(long id)
        {
            var entity = await _orderRepository.FindById(id) ??
                throw new Exception("Não foi possível encontrar esse pedido");

            return OrderMapper.ToDTO(entity);
        }

        public async Task<IEnumerable<OrderDTO>> FindAllAsync()
        {
            var orders = await _orderRepository.FindAll();
            return OrderMapper.ToListDTO(orders);
        }
    }
}

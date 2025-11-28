using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs.Order;
using FastOrder.Application.Mappers;
using FastOrder.Domain.Repositories;

namespace FastOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;

        public OrderService(
            IClientRepository clientRepository,
            IOrderRepository orderRepository)
        {
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
        }

        public async Task<long> PostOrderAsync(OrderPostDTO orderDTO)
        {
            var clientEntity = await _clientRepository.FindById(orderDTO.IdClient);
            if (clientEntity == null)
                throw new Exception($"Cliente de Id: {orderDTO.IdClient} não encontrado");

            var orderEntity = OrderMapper.ToEntity(orderDTO);
            orderEntity.ClientEntity = clientEntity;
            orderEntity.CreatedAt = DateTime.Now;
            orderEntity.UpdateAt = DateTime.Now;

            var result = await _orderRepository.Add(orderEntity);
            return result.Id;
        }

        public async Task<OrderDTO> FindByIdAsync(long id)
        {
            var entity = await _orderRepository.FindById(id);
            if (entity == null)
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

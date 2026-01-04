using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FastOrder.Infra.Repositories.Order
{
    public class OrderRepository(MainContext context) : CrudRepository<long, OrderEntity>(context), IOrderRepository
    {
        public Task<List<OrderEntity>> FindAllByClient(long idClient)
        {
            return context.Set<OrderEntity>()
                .Where(o => o.ClientEntity.Id == idClient)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public override async Task<List<OrderEntity>> FindAll()
        {
            return await context.Set<OrderEntity>()
                .Include(o => o.ClientEntity)
                .ToListAsync();
        }
    }
}

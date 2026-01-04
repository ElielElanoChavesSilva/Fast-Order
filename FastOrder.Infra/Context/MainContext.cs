using FastOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastOrder.Infra.Context
{
    public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ItemOrderEntity> ItemOrders { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

    }
}

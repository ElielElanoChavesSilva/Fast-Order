using FastOrder.Application.Contracts;
using FastOrder.Application.Publishers;
using FastOrder.Application.Services;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Messaging;
using FastOrder.Infra.Repositories.Category;
using FastOrder.Infra.Repositories.Client;
using FastOrder.Infra.Repositories.ItemOrder;
using FastOrder.Infra.Repositories.Order;
using FastOrder.Infra.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace FastOrder
{
    public static class ServiceColletion
    {
        private const string _connectionString = "MsqlConnection";
        public static IServiceCollection ConfigureDatabase(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<MainContext>(option =>
            {
                string conn = configuration.GetConnectionString(_connectionString) ??
                    throw new InvalidOperationException($"Connection string '{_connectionString}' not found."); ;

                option.UseMySql(conn,
                    ServerVersion.AutoDetect(conn));
            });

            return collection;
        }

        public static void ConfigureRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IClientRepository, ClientRepository>();
            collection.AddScoped<IOrderRepository, OrderRepository>();
            collection.AddScoped<IItemOrderRepository, ItemOrderRepository>();
            collection.AddScoped<ICategoryRepository, CategoryRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void ConfigureRabbitMq(this IServiceCollection collection)
        {
            collection.AddSingleton<RabbitMqProducer>();
            collection.AddSingleton<OrderEventPublisher>();
            collection.AddSingleton<RabbitMqConnection>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var hostName = configuration["RabbitMq:HostName"] ?? throw new InvalidOperationException("RabbitMq HostName not configured");
                var userName = configuration["RabbitMq:UserName"] ?? throw new InvalidOperationException("RabbitMq UserName not configured");
                var password = configuration["RabbitMq:Password"] ?? throw new InvalidOperationException("RabbitMq Password not configured");

                return new RabbitMqConnection(hostName, userName, password);
            });
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection collection)
        {
            collection.AddScoped<IClientService, ClientService>();
            collection.AddScoped<IOrderService, OrderService>();
            collection.AddScoped<IItemOrderService, ItemOrderService>();
            collection.AddScoped<IAuthenticationService, AuthenticationService>();
            collection.AddScoped<ICategoryService, CategoryService>();
            collection.AddScoped<IProductService, ProductService>();

            return collection;
        }
    }
}

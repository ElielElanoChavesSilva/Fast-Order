using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastOrder.Infra.Repository
{
    public static class ServiceColletion
    {
        private const string _connectionString = "";
        public static IServiceCollection ConfigureDatabase(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<MainContext>(option =>
            {
                option.UseMySql(configuration.GetConnectionString(_connectionString), ServerVersion.AutoDetect(_connectionString));
            });


            return collection;
        }


        public static IServiceCollection ConfigureRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IClientRepository, ClientRepository>()
        }
    }
}

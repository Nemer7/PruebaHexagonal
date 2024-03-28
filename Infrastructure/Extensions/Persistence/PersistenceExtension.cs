using Domain.Ports;
using Infrastructure.Adapters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure.Extensions.Persistence
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPesistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IMongoDatabase>((sp) =>
            {
                var database = System.Environment.GetEnvironmentVariable("MONGO_DATABASE");
                var databaseName = System.Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");
                var client = new MongoClient(database);
                return client.GetDatabase(databaseName);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Contexts
{
    public class MongoContext <T>
    {
        public IMongoDatabase _mongoDatabase;
        public MongoContext(IConfiguration configuration)
        {
            var database = System.Environment.GetEnvironmentVariable("MONGO_DATABASE");
            var databasename = System.Environment.GetEnvironmentVariable("MONGO_DATABASE_NAME");
            var client = new MongoClient(database);
            _mongoDatabase = client.GetDatabase(databasename);
        }

        public IMongoCollection<T> DataBase => _mongoDatabase.GetCollection<T>(typeof(T).Name);
        


    }
}

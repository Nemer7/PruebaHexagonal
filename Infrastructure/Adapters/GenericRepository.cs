using Domain.Entities.Base;
using Domain.Ports;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Infrastructure.Adapters
{
    public class GenericRepository <T> : IGenericRepository<T> where T : BaseEntity<string>
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name);
        }
        public async Task Add(T entity)
        {
            entity.SetCreationDate();
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(T entity)
        {
            var filter = Builders<T>.Filter.And(Builders<T>.Filter.Eq(x => x.IsActive, true),
                Builders<T>.Filter.Eq(x => x.Id, entity.Id)); 

            entity.SetModificationDate();
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(x => x.IsActive).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            var filter = Builders<T>.Filter.And(Builders<T>.Filter.Eq(x => x.IsActive, true),
                               Builders<T>.Filter.Eq(x => x.Id, id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(T entity)
        {
           var filter = Builders<T>.Filter.And( Builders<T>.Filter.Eq(x => x.Id, entity.Id)); 

            entity.SetModificationDate();
            await _collection.ReplaceOneAsync(filter, entity); 
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

    }
}

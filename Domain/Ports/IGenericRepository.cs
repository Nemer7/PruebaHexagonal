using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Domain.Ports
{
    public interface IGenericRepository<T> where T : BaseEntity<string>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(string id);
        Task <IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);


            


        



    }
}

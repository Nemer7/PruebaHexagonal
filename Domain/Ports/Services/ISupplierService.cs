using Domain.Entities;

namespace Domain.Ports.Services
{
    public interface ISupplierService
    {
        Task<Supplier> Add(Supplier supplier);
        Task Update(Supplier supplier, string id);
        Task Delete(Supplier supplier);
        Task<Supplier> GetById(string id);
        Task<IEnumerable<Supplier>> GetAll();
    }
}

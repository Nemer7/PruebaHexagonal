using Domain.Common.Wrappers;
using Domain.Entities;
using Domain.Ports;
using Domain.Ports.Services;
using System.Reflection;

namespace Domain.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IGenericRepository<Supplier> _supplierRepository;

        public SupplierService(IGenericRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier> Add(Supplier supplier)
        {
            var supplierExist = await _supplierRepository.FindAsync(x => x.NIT == supplier.NIT);
            if (supplierExist.Any())
            {
                throw new Exception( "Supplier already exist");
            }
           await _supplierRepository.Add(supplier);

            return supplier;
           
        }

        public async Task Delete(Supplier supplier)
        {
            supplier.IsActive = false;
            await _supplierRepository.Delete(supplier);

        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var supplierList = await _supplierRepository.GetAll();

            return supplierList;

        }

        public async Task<Supplier> GetById(string id)
        {
           var supplier = await _supplierRepository.GetById(id);

            return supplier;
        }

        public async Task Update(Supplier supplier, string id)
        {
            var supplierExist = await _supplierRepository.GetById(id);

          

            var properties = typeof(Supplier).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {

                var value = property.GetValue(supplier);
                if (value != null && value != DBNull.Value && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    property.SetValue(supplierExist, value);
                }
            }

            await _supplierRepository.Update(supplierExist);

        }
    }
}

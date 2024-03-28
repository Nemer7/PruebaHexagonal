using Application.UseCases.Suppliers.Dto;

namespace Application.UseCases.Supplier.Queries.GetAllSupplier
{
    public record GetAllSupplierQuery: IRequest<Response<IEnumerable<SupplierDto>>>;
    
}

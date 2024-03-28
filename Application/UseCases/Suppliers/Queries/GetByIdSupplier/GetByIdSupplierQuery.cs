using Application.UseCases.Suppliers.Dto;

namespace Application.UseCases.Supplier.Queries.GetByIdSupplier
{
    public record GetByIdSupplierQuery(string id): IRequest<Response<SupplierDto>>; 
    
}

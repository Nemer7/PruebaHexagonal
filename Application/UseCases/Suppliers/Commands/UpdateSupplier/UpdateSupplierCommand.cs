using Application.UseCases.Suppliers.Dto;
using Domain.Entities;

namespace Application.UseCases.Supplier.Commands.UpdateSupplier
{
   public record UpdateSupplierCommand( string id, string NIT, string BusinessName, string Email,
       Location Location, ContactInformation ContactInformation): IRequest<Response<string>>;
    
}

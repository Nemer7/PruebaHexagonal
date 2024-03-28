using Domain.Entities;

namespace Application.UseCases.Suppliers.Dto
{
    public record SupplierDto(string Id,string NIT,string BusinessName, string Email, Location Location, ContactInformation ContactInformation);
   
   
}

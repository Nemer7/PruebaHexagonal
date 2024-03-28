using Application.UseCases.Suppliers.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.UseCases.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand(
        string NIT,
        string BusinessName,
        string Email,
        Location Location,
        ContactInformation ContactInformation
      
        ) :  IRequest<Response<SupplierDto>>;
   
}

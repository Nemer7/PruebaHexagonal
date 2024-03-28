

using Domain.Ports.Services;

namespace Application.UseCases.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Response<string>>
    {
        private readonly ISupplierService _supplierService;

        public UpdateSupplierCommandHandler(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public async Task<Response<string>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierService.GetById(request.id);

            if (supplier == null)
            {
                throw new Exception("Supplier not found");
            }

            var supplierUpdate = new Domain.Entities.Supplier(
                request.NIT,
                request.BusinessName,
                request.Email,
                request.Location,
                request.ContactInformation);
           
           await _supplierService.Update(supplierUpdate, request.id);

            return new Response<string>(200, "Supplier updated successfully") {Success = true };
        }
    }
}

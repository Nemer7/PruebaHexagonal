
using Domain.Ports.Services;

namespace Application.UseCases.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, Response<string>>
    {
        private readonly ISupplierService _service;

        public DeleteSupplierCommandHandler(ISupplierService service)
        {
            _service = service;
        }
        public async Task<Response<string>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            
            var supplier = await _service.GetById(request.Id);
            if (supplier == null)
            {
                return new Response<string>("Supplier not found");
            }
            await _service.Delete(supplier);
            return new Response<string>("Supplier deleted");


        }
    }
}

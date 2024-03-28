using Application.UseCases.Suppliers.Dto;
using Domain.Entities;
using Domain.Ports.Services;

namespace Application.UseCases.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Response<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Response<SupplierDto>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
           

            var supplier = new  Domain.Entities.Supplier(request.NIT, request.BusinessName, request.Email, request.Location, request.ContactInformation);
           
            
            await _supplierService.Add(supplier);

            var supplierMap = _mapper.Map<SupplierDto>(supplier);

            return new Response<SupplierDto>(supplierMap);

        }
    }
}

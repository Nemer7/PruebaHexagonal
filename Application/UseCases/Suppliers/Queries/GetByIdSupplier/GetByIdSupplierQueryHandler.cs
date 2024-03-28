using Application.UseCases.Suppliers.Dto;
using Domain.Ports.Services;

namespace Application.UseCases.Supplier.Queries.GetByIdSupplier
{
    public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQuery, Response<SupplierDto>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        
        public GetByIdSupplierQueryHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        public async Task<Response<SupplierDto>> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
        {
            

            var supplier = await _supplierService.GetById(request.id);
            if (supplier == null) {                
                throw new Exception( "Supplier not found");
            }
            var supplierMap = _mapper.Map<SupplierDto>(supplier);

            return new Response<SupplierDto>(supplierMap);

        }
    }   
}


using Application.UseCases.Suppliers.Dto;
using Domain.Ports.Services;

namespace Application.UseCases.Supplier.Queries.GetAllSupplier
{
    public record GetAllSupplierQueryHandler : IRequestHandler<GetAllSupplierQuery, Response<IEnumerable<SupplierDto>>>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public GetAllSupplierQueryHandler(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<SupplierDto>>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierService.GetAll();
            var suppliersMap = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);

            return new Response<IEnumerable<SupplierDto>>(suppliersMap);


        }
    }
}

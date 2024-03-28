using Application.UseCases.Suppliers.Dto;
using Domain.Entities;

namespace Application
{
    public class MapperProfile: Profile
    {
       public MapperProfile()
        {
         
            #region SupplierZone
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            #endregion

        }





    }
}

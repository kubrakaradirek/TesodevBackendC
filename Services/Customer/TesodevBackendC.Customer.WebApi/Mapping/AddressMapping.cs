using AutoMapper;
using TesodevBackendC.Customer.WebApi.Dtos.AddressDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Mapping
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, ResultAddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<Address, GetAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();
            
        }
    }
}

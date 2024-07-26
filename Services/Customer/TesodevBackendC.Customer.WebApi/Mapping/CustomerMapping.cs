using AutoMapper;
using TesodevBackendC.Customer.WebApi.Dtos.AddressDtos;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Mapping
{
    public class CustomerMapping:Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customerr, ResultCustomerDto>().ReverseMap();
            CreateMap<Customerr, CreateCustomerDto>().ReverseMap();
            CreateMap<Customerr, GetCustomerDto>().ReverseMap();
            CreateMap<Customerr, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customerr, CustomerWithAddressesDto>()
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ReverseMap();
        }
    }
}

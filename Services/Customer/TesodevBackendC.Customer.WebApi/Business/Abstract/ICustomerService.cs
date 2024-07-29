using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Business.Abstract
{
    public interface ICustomerService : IGenericService<Customerr>
    {
        CustomerWithAddressesDto GetCustomerWithAddresses(Guid id);
        List<ResultCustomerDto> TGetCustomerListWithAddresses();
        bool TValidateCustomer(Guid customerId);
    }
}

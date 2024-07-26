using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Business.Abstract
{
    public interface ICustomerService : IGenericService<Customerr>
    {
        List<ResultCustomerDto> GetCustomerListWithAddresses();

    }
}

using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.DataAccess.Abstract
{
    public interface ICustomerDal : IGenericDal<Customerr>
    {
        CustomerWithAddressesDto GetCustomerWithAddresses(Guid id);
        List<Customerr> GetCustomerListWithAddresses();
        bool ValidateCustomer(Guid customerId);
    }
}

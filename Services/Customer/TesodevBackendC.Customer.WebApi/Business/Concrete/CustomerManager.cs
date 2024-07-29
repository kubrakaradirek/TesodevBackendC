using AutoMapper;
using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.EntityFramework;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal CustomerDal,IMapper mapper)
        {
            _customerDal = CustomerDal;
            _mapper=mapper;
        }
        public void TCreate(Customerr entity)
        {
            _customerDal.Create(entity);
        }
        public void TDelete(Customerr entity)
        {
            _customerDal.Delete(entity);
        }
        public Customerr TGetById(Guid id)
        {
            return _customerDal.GetById(id);
        }
        public List<Customerr> TGetListAll()
        {
            return _customerDal.GetListAll();
        }
        public void TUpdate(Customerr entity)
        {
            _customerDal.Update(entity);
        }
        public CustomerWithAddressesDto GetCustomerWithAddresses(Guid id)
        {
            var customer = _customerDal.GetCustomerWithAddresses(id);
            return _mapper.Map<CustomerWithAddressesDto>(customer);
        }
        public bool TValidateCustomer(Guid customerId)
        {
            return _customerDal.ValidateCustomer(customerId);
        }
        public List<ResultCustomerDto> TGetCustomerListWithAddresses()
        {
            var customers = _customerDal.GetCustomerListWithAddresses();
            return _mapper.Map<List<ResultCustomerDto>>(customers);
        }
    }
}

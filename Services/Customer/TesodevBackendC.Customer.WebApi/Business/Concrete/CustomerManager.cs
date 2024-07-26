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
        private readonly ICustomerDal _CustomerDal;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal CustomerDal,IMapper mapper)
        {
            _CustomerDal = CustomerDal;
            _mapper=mapper;
        }

        public void TCreate(Customerr entity)
        {
            _CustomerDal.Create(entity);
        }

        public void TDelete(Customerr entity)
        {
            _CustomerDal.Delete(entity);
        }

        public Customerr TGetById(Guid id)
        {
            return _CustomerDal.GetById(id);
        }

        public List<Customerr> TGetListAll()
        {
            return _CustomerDal.GetListAll();
        }

        public void TUpdate(Customerr entity)
        {
            _CustomerDal.Update(entity);
        }
        public List<ResultCustomerDto> GetCustomerListWithAddresses()
        {
            var customers = _CustomerDal.GetCustomerListWithAddresses();
            return _mapper.Map<List<ResultCustomerDto>>(customers);
        }
    }
}

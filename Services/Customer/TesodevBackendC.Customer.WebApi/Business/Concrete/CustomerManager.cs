using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal CustomerDal)
        {
            _CustomerDal = CustomerDal;
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

    }
}

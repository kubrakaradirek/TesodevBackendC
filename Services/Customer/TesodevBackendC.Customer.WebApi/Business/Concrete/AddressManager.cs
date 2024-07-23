using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void TCreate(Address entity)
        {
           _addressDal.Create(entity);
        }

        public void TDelete(Address entity)
        {
            _addressDal.Delete(entity);
        }

        public Address TGetById(int id)
        {
            return _addressDal.GetById(id);
        }

        public List<Address> TGetListAll()
        {
            return _addressDal.GetListAll();
        }

        public void TUpdate(Address entity)
        {
            _addressDal.Update(entity);
        }
    }
}

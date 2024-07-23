using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Concrete;
using TesodevBackendC.Customer.WebApi.DataAccess.Repositories;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.DataAccess.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customerr>, ICustomerDal
    {
        public EfCustomerDal(CustomerDbContext context) : base(context)
        {
        }
    }
}

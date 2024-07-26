using Microsoft.EntityFrameworkCore;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Concrete;
using TesodevBackendC.Customer.WebApi.DataAccess.Repositories;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.DataAccess.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customerr>, ICustomerDal
    {
        private readonly CustomerDbContext _context;
        public EfCustomerDal(CustomerDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Customerr> GetCustomerListWithAddresses()
        {
            return _context.Customerrs.Include(c=>c.Addresses).ToList();    
      
        }
    }
}

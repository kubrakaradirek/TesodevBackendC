using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Concrete;
using TesodevBackendC.Customer.WebApi.DataAccess.Repositories;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.DataAccess.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customerr>, ICustomerDal
    {
        private readonly CustomerDbContext _context;
        IMapper _mapper;
        public EfCustomerDal(CustomerDbContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Customerr> GetCustomerListWithAddresses()
        {
            return _context.Customerrs.Include(c => c.Addresses).ToList();
        }
        public CustomerWithAddressesDto GetCustomerWithAddresses(Guid id)
        {
            var customer = _context.Customerrs.Include(c => c.Addresses).FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return null;
            }
            return _mapper.Map<CustomerWithAddressesDto>(customer);
        }
        public bool ValidateCustomer(Guid customerId)
        {
            return _context.Customerrs.Any(c => c.Id == customerId);
        }
    }
}

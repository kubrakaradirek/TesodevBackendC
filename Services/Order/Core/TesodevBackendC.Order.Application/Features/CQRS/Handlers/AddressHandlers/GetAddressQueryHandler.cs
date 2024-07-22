using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Results.AddressResults;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x=>new GetAddressQueryResult
            {
                Id = x.Id,
                Country = x.Country,    
                City = x.City,  
                CityCode = x.CityCode,  
                OrderId = x.OrderId
            }).ToList();
        }
    }
}

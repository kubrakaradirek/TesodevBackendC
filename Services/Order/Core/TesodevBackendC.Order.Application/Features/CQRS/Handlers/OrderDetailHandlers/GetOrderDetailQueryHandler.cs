using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Price = x.Price,
                Quantity = x.Quantity,
                Status = x.Status,
                AddressId = x.AddressId,
                CustomerId= x.CustomerId

            }).ToList();
        }
    }
}

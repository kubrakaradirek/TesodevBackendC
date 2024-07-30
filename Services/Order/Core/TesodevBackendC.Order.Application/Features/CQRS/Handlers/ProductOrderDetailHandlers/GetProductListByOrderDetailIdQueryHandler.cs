using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries;
using TesodevBackendC.Order.Application.Features.CQRS.Results.ProductOrderDetailResults;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductOrderDetailHandlers
{
    public class GetProductListByOrderDetailIdQueryHandler
    {
        private readonly IRepository<ProductOrderDetail> _repository;
        public GetProductListByOrderDetailIdQueryHandler(IRepository<ProductOrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetProductListByOrderDetailIdQueryResult> Handle(GetProductListByOrderDetailIdQuery query)
        {
            var productList = await _repository.GetProductListByOrderDetailIdAsync(query.OrderDetailId);
            return new GetProductListByOrderDetailIdQueryResult
            {
                OrderDetailId = query.OrderDetailId,
                Products = productList
            };
        }
    }
}

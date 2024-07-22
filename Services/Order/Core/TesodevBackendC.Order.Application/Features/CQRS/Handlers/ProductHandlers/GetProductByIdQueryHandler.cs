using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductQueries;
using TesodevBackendC.Order.Application.Features.CQRS.Results.ProductResults;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IRepository<Product> _repository;
        public GetProductByIdQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetProductByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                ImageUrl = values.ImageUrl
            };

        }
    }
}

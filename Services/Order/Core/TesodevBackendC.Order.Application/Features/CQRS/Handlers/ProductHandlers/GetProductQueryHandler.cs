using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Results.ProductResults;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly IRepository<Product> _repository;
        public GetProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetProductQueryResult
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name

            }).ToList();
        }
    }
}

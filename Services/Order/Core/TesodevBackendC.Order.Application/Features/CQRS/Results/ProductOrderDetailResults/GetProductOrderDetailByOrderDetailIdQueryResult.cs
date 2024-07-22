using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Results.ProductOrderDetailResults
{
    internal class GetProductOrderDetailByOrderDetailIdQueryResult
    {
        public Guid OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public Guid ProductId { get; set; }
    }
}

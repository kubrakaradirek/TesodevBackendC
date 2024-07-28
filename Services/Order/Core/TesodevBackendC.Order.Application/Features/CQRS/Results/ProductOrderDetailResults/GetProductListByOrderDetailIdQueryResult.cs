using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Results.ProductOrderDetailResults
{
    public class GetProductListByOrderDetailIdQueryResult
    {
        public Guid OrderDetailId { get; set; }
        public List<string> Products { get; set; }
    }
}

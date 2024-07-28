using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries
{
    public class GetProductListByOrderDetailIdQuery
    {
        public Guid OrderDetailId { get; set; }

        public GetProductListByOrderDetailIdQuery(Guid orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}

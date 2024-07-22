using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries
{
    public class GetProductOrderDetailByOrderDetailIdQuery
    {
        public int Id { get; set; }
        public GetProductOrderDetailByOrderDetailIdQuery(int id)
        {
            Id = id;
        }
    }
}

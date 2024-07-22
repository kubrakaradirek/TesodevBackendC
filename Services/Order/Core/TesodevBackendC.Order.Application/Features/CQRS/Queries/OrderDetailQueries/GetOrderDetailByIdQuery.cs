using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public Guid Id { get; set; }
        public GetOrderDetailByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailQueryResult
    {
        public Guid Id { get; set; }
        public Guid CustomerrId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AddressId { get; set; }
    }
}

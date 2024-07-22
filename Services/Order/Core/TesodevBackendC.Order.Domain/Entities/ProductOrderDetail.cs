using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TesodevBackendC.Order.Domain.Entities
{
    public class ProductOrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        //Many to many Order
        public List<ProductOrder> ProductOrders { get; set; }
    }
}

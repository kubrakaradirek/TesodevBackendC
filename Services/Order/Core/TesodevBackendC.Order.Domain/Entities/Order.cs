using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //One to one relationship
        public Address Address { get; set; }
        //Many to many Product
        public List<ProductOrder> ProductOrders { get; set; }

    }
}

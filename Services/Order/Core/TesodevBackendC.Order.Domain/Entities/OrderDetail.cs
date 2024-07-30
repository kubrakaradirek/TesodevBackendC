using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Domain.Entities
{
    //This name is used in place of the Order table
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid CustomerrId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AddressId { get; set; }
        //Many to many Product
        public List<ProductOrderDetail> ProductOrders { get; set; }
    }
}

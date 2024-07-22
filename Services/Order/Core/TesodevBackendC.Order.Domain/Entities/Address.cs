using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        //One to one relationship
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

    }
}

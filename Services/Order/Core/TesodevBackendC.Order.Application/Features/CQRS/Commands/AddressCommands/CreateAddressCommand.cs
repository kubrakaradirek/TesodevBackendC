using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public Guid OrderId { get; set; }
    }
}

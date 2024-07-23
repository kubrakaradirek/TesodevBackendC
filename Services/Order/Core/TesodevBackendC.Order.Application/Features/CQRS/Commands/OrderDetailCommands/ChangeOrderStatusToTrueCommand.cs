using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class ChangeOrderStatusToTrueCommand
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public Guid Id { get; set; }
        public DeleteOrderDetailCommand(Guid id)
        {
            Id = id;
        }
    }
}

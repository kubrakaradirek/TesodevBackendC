using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands
{
    public class DeleteProductCommand
    {
        public Guid Id { get; set; }
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}

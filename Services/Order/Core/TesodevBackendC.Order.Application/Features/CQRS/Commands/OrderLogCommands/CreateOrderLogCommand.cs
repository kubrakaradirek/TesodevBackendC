using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderLogCommands
{
    public class CreateOrderLogCommand
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public CreateOrderLogCommand(string message, DateTime createdAt)
        {
            Message = message;
            CreatedAt = createdAt;
        }
    }
}

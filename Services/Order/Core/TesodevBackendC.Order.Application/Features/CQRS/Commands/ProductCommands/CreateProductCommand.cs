using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}

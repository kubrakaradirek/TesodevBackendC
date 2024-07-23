using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class ChangeOrderStatusToFalseCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public ChangeOrderStatusToFalseCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ChangeOrderStatusToFalseCommand command)
        {
            return await _repository.ChangeOrderStatusToFalseAsync(command.OrderId, command.Status);
        }
    }
}

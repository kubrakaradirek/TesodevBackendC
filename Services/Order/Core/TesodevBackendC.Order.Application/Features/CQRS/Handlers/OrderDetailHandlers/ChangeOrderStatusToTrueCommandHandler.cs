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
    public class ChangeOrderStatusToTrueCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public ChangeOrderStatusToTrueCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ChangeOrderStatusToTrueCommand command)
        {
            return await _repository.ChangeOrderStatusToTrueAsync(command.OrderId, command.Status);
        }
    }
}

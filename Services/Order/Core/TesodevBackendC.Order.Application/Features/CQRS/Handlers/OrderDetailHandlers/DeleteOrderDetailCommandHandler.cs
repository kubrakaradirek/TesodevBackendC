using FluentValidation;
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
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}

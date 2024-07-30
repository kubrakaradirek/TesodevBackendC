using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderLogCommands;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderLogHandlers
{
    public class CreateOrderLogCommandHandler
    {
        private readonly IRepository<OrderLog> _repository;
        public CreateOrderLogCommandHandler(IRepository<OrderLog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderLogCommand command)
        {
            await _repository.CreateAsync(new OrderLog
            {
                CreatedAt = DateTime.Now,
                Message = command.Message,
            });
        }
    }
}

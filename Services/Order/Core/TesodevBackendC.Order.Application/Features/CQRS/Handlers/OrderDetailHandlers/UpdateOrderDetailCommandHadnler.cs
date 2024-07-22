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
    public class UpdateOrderDetailCommandHadnler
    {
        private readonly IRepository<OrderDetail> _repository;
        public UpdateOrderDetailCommandHadnler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Quantity = command.Quantity;
            values.Price = command.Price;
            values.Status = command.Status;
            values.CreatedAt = command.CreatedAt;
            values.UpdatedAt = command.UpdatedAt;
            await _repository.UpdateAsync(values);
        }
    }
}

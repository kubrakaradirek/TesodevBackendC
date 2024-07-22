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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                Quantity = command.Quantity,
                Price = command.Price,
                Status = command.Status,
                CreatedAt=command.CreatedAt,
                UpdatedAt=command.UpdatedAt,
                AddressId=command.AddressId,
                CustomerId=command.CustomerId,
            });
        }
    }
}

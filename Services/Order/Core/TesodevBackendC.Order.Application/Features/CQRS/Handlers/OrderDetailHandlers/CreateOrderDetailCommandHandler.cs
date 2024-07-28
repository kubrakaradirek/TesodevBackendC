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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IValidator<CreateOrderDetailCommand> _validator;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IValidator<CreateOrderDetailCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            await _repository.CreateAsync(new OrderDetail
            {
                Quantity = command.Quantity,
                Price = command.Price,
                Status = "Sipariş oluşturuldu",
                CreatedAt = DateTime.Now,
                AddressId = command.AddressId,
                CustomerrId = command.CustomerrId,
            });
        }
    }
}

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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IValidator<UpdateOrderDetailCommand> _validator;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IValidator<UpdateOrderDetailCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var values = await _repository.GetByIdAsync(command.Id);
            values.Quantity = command.Quantity;
            values.Price = command.Price;
            values.UpdatedAt = DateTime.Now;
            values.AddressId = command.AddressId;
            values.CustomerrId = command.CustomerrId;
            await _repository.UpdateAsync(values);
        }
    }
}

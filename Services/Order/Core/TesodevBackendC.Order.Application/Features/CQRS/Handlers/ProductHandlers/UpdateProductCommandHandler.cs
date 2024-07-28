using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<UpdateProductCommand> _validator;
        public UpdateProductCommandHandler(IRepository<Product> repository, IValidator<UpdateProductCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Handle(UpdateProductCommand command)
        {
            var validationResult=await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}

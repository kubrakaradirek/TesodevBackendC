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
    public class CreateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(IRepository<Product> repository, IValidator<CreateProductCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task Handle(CreateProductCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.CreateAsync(new Product
            {
                ImageUrl = command.ImageUrl,
                Name = command.Name
            });
        }
    }
}

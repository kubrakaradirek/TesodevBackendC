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
    public class DeleteProductCommandHandler
    {
        private readonly IRepository<Product> _repository;
        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteProductCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}

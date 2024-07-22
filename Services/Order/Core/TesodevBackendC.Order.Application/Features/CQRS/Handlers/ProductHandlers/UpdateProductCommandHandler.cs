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
        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateProductCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}

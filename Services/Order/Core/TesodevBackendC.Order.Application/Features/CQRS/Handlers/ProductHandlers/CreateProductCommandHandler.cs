﻿using System;
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
        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateProductCommand command)
        {
            await _repository.CreateAsync(new Product
            {
                ImageUrl = command.ImageUrl,
                Name = command.Name
            });
        }
    }
}
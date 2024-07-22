using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.AddressCommands;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandhandler
    {
        private readonly IRepository<Address> _repository;
        public CreateAddressCommandhandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Country = createAddressCommand.Country,
                CityCode = createAddressCommand.CityCode,
                OrderId=createAddressCommand.OrderId

            });
        }
    }
}

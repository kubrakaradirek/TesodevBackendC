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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values=await _repository.GetByIdAsync(command.Id);
            values.Country=command.Country;
            values.City=command.City;
            values.CityCode=command.CityCode;
            values.OrderDetailId = command.OrderDetailId;
            await _repository.UpdateAsync(values);
        }
    }
}

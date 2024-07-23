using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.Dtos.AddressDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult AddressList()
        {
            var values = _addressService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAddress(CreateAddressDto createAddressDto)
        {
            Address address = new Address()
            {
                AddressLine = createAddressDto.AddressLine,
                City = createAddressDto.City,
                CityCode = createAddressDto.CityCode,
                Country = createAddressDto.Country,
                CustomerId = createAddressDto.CustomerId,
                OrderDetailId = createAddressDto.OrderDetailId
            };
            _addressService.TCreate(address);
            return Ok("Adres başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(Guid id)
        {
            var value = _addressService.TGetById(id);
            _addressService.TDelete(value);
            return Ok("Adres başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            Address address = new Address()
            {
                Id = updateAddressDto.Id,
                AddressLine = updateAddressDto.AddressLine,
                City = updateAddressDto.City,
                CityCode = updateAddressDto.CityCode,
                Country = updateAddressDto.Country,
                CustomerId = updateAddressDto.CustomerId,
                OrderDetailId = updateAddressDto.OrderDetailId
            };
            _addressService.TUpdate(address);
            return Ok("Adres başarı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            var value = _addressService.TGetById(id);
            return Ok(value);
        }
    }
}

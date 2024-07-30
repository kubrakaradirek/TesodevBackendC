using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.Dtos.AddressDtos;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CreateCustomerDto> _createCustomerValidator;
        private readonly IValidator<UpdateCustomerDto> _updateCustomerValidator;
        public CustomersController(ICustomerService customerService, IValidator<CreateCustomerDto> createCustomerValidator, IValidator<UpdateCustomerDto> updateCustomerValidator)
        {
            _customerService = customerService;
            _createCustomerValidator = createCustomerValidator;
            _updateCustomerValidator = updateCustomerValidator;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var customers = _customerService.TGetCustomerListWithAddresses();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var validationResult = _createCustomerValidator.Validate(createCustomerDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            Customerr customerr = new Customerr()
            {
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
                CreatedAt = DateTime.Now,
            };
            _customerService.TCreate(customerr);
            return Ok("Müşteri başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var value = _customerService.TGetById(id);
            _customerService.TDelete(value);
            return Ok("Müşteri başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var validationResult = _updateCustomerValidator.Validate(updateCustomerDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var values = _customerService.TGetById(updateCustomerDto.Id);
            values.Id = updateCustomerDto.Id;
            values.Name = updateCustomerDto.Name;
            values.Email = updateCustomerDto.Email;
            values.UpdatedAt = DateTime.Now;
            _customerService.TUpdate(values);
            return Ok("Müşteri başarı bir şekilde güncellendi.");
        }

        [HttpGet("GetCustomersWithAddresses/{id}")]
        public IActionResult GetCustomersWithAddresses(Guid id)
        {
            var result = _customerService.GetCustomerWithAddresses(id);
            return Ok(result);
        }

        [HttpGet("ValidateCustomer/{id}")]
        public IActionResult ValidateCustomer(Guid id)
        {
            var value = _customerService.TValidateCustomer(id);
            return Ok(value);
        }
    }
}

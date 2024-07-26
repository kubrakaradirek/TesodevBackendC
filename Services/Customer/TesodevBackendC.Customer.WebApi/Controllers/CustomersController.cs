using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    { 
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var customers = _customerService.GetCustomerListWithAddresses();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            Customerr customerr = new Customerr()
            {
                Name= createCustomerDto.Name,
                Email= createCustomerDto.Email,
                CreatedAt= DateTime.Now,
                UpdatedAt= DateTime.Now
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
            Customerr customer = new Customerr()
            {
                Id= updateCustomerDto.Id,
                Name= updateCustomerDto.Name,
                Email= updateCustomerDto.Email,
                CreatedAt= DateTime.Now,
                UpdatedAt= DateTime.Now
            };
            _customerService.TUpdate(customer);
            return Ok("Müşteri başarı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
    }
}

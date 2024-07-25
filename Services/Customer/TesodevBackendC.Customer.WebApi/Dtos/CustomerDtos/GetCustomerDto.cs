using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos
{
    public class GetCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

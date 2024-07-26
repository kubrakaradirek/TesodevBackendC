namespace TesodevBackendC.Customer.WebApi.Dtos.AddressDtos
{
    public class AddressDto
    {
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}

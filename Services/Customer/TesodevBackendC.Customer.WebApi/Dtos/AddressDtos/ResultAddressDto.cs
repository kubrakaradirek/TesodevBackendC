﻿using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.Dtos.AddressDtos
{
    public class ResultAddressDto
    {
        public Guid Id { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
        public Guid CustomerrId { get; set; }
    }
}

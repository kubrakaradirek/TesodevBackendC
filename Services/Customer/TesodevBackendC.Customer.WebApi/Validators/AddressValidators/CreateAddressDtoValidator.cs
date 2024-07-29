using FluentValidation;
using TesodevBackendC.Customer.WebApi.Dtos.AddressDtos;

namespace TesodevBackendC.Customer.WebApi.Validators.AddressValidator
{
    public class CreateAddressDtoValidator : AbstractValidator<CreateAddressDto>
    {
        public CreateAddressDtoValidator()
        {
            RuleFor(address => address.AddressLine1)
               .NotEmpty().WithMessage("Birinci adres alanı boş geçilemez.")
               .MinimumLength(10).WithMessage("Birinci adres e az 10 karakterden oluşmalıdır");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("Şehir alanı boş geçilemez.");

            RuleFor(address => address.Country)
                .NotEmpty().WithMessage("Ülke alanı boş geçilemez.");

            RuleFor(address => address.CityCode)
                .NotEmpty().WithMessage("Posta kodu alanı boş geçilemez.")
                .GreaterThan(0).WithMessage("Posta kodu sıfırdan büyük olmalıdır.");
        }
    }
}

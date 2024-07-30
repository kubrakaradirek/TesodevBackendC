using FluentValidation;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;

namespace TesodevBackendC.Customer.WebApi.Validators.CustomerValidators
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(customer => customer.Name)
           .NotEmpty().WithMessage("Müşteri adı boş geçilemez.")
           .Length(3, 60).WithMessage("Müşteri adı 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(customer => customer.Email)
           .NotEmpty().WithMessage("Email boş geçilemez.")
           .EmailAddress().WithMessage("eçerli bir email adresi giriniz.");
        }
    }
}

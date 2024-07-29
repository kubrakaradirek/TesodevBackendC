using FluentValidation;
using TesodevBackendC.Customer.WebApi.Dtos.CustomerDtos;

namespace TesodevBackendC.Customer.WebApi.Validators.CustomerValidators
{
    public class CreateCustomerDtoValidator:AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(customer => customer.Name)
           .NotEmpty().WithMessage("Müşteri adı boş geçilemez.")
           .Length(3, 60).WithMessage("Müşteri adı 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(customer => customer.Email)
           .NotEmpty().WithMessage("Email boş geçilemez.")
           .EmailAddress().WithMessage("eçerli bir email adresi giriniz.");

            RuleFor(customer => customer.CreatedAt)
           .NotEmpty().WithMessage("Oluşturulma tarihi boş geçilemez.")
           .LessThanOrEqualTo(DateTime.Now).WithMessage("Oluşturulma tarihi bugünden ileride olamaz.");
        }
    }
}

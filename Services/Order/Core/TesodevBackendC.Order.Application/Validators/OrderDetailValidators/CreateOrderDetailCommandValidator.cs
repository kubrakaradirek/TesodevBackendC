using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

namespace TesodevBackendC.Order.Application.Validators.OrderDetailValidators
{
    public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
        {
            RuleFor(command => command.Quantity)
                .NotEmpty().WithMessage("Miktar alanı boş geçilemez.")
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır");

            RuleFor(command => command.Price)
               .NotEmpty().WithMessage("Fiyat alanı boş geçilemez.")
               .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır");

            RuleFor(command => command.CreatedAt)
                .NotEmpty().WithMessage("Oluşturulma tarihi boş geçilemez.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Oluşturulma tarihi gelecek tarihte olamaz.");
        }
    }
}

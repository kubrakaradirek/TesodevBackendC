using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands;

namespace TesodevBackendC.Order.Application.Validators.ProductValidators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name)
              .NotEmpty().WithMessage("Ürün adı boş geçilemez.")
              .MaximumLength(35).WithMessage("Ürün adı 35 karakteri geçmemelidir.")
              .MinimumLength(2).WithMessage("Ürün adı 2 karakterden az olmamalıdır.");

            RuleFor(command => command.ImageUrl)
              .NotEmpty().WithMessage("Resim URL'si boş geçilemez.")
              .MinimumLength(8).WithMessage("Resim URL'si 8 karakterden az olmamalıdır.");
        }
    }
}

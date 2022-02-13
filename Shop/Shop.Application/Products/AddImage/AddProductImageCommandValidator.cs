using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(b => b.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(b => b.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }
}
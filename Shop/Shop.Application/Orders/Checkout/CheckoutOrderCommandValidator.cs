using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(f => f.Family)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(f => f.City)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(f => f.Shire)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PostalAddress)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PostalCode)
             .NotNull()
             .NotEmpty()
             .WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.PhoneNumber)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("شماره"))
              .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است")
              .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است");

            RuleFor(f => f.NationalCode)
             .NotNull()
             .NotEmpty()
             .WithMessage(ValidationMessages.required("کد ملی"))
             .MaximumLength(10).WithMessage(" کدملی نامعتبر است")
             .MinimumLength(10).WithMessage("کدملی نامعتبر است")
             .ValidNationalId();
        }
    }
}
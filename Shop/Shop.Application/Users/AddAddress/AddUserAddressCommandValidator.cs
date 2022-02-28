using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

public class AddUserAddressCommandValidator:AbstractValidator<AddUserAddressCommand>
{
    public AddUserAddressCommandValidator()
    {
        RuleFor(f => f.City)
            .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(f => f.Shire)
            .NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(f => f.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(f => f.Family)
            .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(f => f.NationalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
            .ValidNationalId();

        RuleFor(f => f.PostalAddress)
            .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

        RuleFor(f => f.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
    }
}
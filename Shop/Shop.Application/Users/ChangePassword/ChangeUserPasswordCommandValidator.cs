using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChangePassword;

public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
{
    public ChangeUserPasswordCommandValidator()
    {
        RuleFor(r => r.CurrentPassword)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور فعلی"))
            .MinimumLength(5).WithMessage(ValidationMessages.required("کلمه عبور فعلی"));

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور فعلی"))
            .MinimumLength(5).WithMessage(ValidationMessages.required("کلمه عبور فعلی"));
    }
}
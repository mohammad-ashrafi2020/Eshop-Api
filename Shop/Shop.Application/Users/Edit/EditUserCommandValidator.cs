using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(r => r.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("ایمیل نامعتبر است");

        RuleFor(f => f.Password)
            .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");

        RuleFor(f => f.Avatar)
            .JustImageFile();
    }
}
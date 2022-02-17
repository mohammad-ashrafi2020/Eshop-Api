using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Edit;

public class EditRoleCommandCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}
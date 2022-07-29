using FluentValidation;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
{
    public EditShippingMethodCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotNull().NotEmpty();
    }
}
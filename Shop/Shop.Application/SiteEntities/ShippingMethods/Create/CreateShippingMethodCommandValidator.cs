using FluentValidation;

namespace Shop.Application.SiteEntities.ShippingMethods.Create;

public class CreateShippingMethodCommandValidator : AbstractValidator<CreateShippingMethodCommand>
{
    public CreateShippingMethodCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotNull().NotEmpty();
    }
}
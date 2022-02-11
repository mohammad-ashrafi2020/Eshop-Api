using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandValidator
    : AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidator()
    {
        RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}
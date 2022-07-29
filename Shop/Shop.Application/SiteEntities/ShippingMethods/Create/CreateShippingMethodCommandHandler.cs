using Common.Application;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.ShippingMethods.Create;

internal class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new ShippingMethod(request.Cost, request.Title));
        await _repository.Save();
        return OperationResult.Success();
    }
}
using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory;

internal class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public EditSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
            return OperationResult.NotFound();

        seller.EditInventory(request.InventoryId,request.Count,request.Price,request.DiscountPercentage);
        await _repository.Save();
        return OperationResult.Success();
    }
}
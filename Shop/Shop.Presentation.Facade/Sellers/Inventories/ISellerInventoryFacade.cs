using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;

namespace Shop.Presentation.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
}

internal class SellerInventoryFacade : ISellerInventoryFacade
{
    private readonly IMediator _mediator;

    public SellerInventoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }
}

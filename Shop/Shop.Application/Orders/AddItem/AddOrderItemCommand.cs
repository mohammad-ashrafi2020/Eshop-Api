using Common.Application;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommand : IBaseCommand
{
    public AddOrderItemCommand(long inventoryId, int count, long userId)
    {
        InventoryId = inventoryId;
        Count = count;
        UserId = userId;
    }

    public long InventoryId { get;  set; }
    public int Count { get;  set; }
    public long UserId { get;  set; }
}
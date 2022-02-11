using Common.Application;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(long UserId, long ItemId) : IBaseCommand;
}
using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
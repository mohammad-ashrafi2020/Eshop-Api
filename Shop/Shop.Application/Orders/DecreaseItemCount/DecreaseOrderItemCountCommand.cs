using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount;
public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
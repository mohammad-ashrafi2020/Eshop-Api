using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;

namespace Shop.Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
    Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
    Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);



    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
}
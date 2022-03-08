using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById;

public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;
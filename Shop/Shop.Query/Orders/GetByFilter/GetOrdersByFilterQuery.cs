using Common.Query;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}
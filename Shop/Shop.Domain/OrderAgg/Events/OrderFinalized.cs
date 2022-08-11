using Common.Domain;
using MediatR;

namespace Shop.Domain.OrderAgg.Events;

public class OrderFinalized : BaseDomainEvent
{
    public OrderFinalized(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; private set; }
}
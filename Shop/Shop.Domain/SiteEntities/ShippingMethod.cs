using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities;

public class ShippingMethod : BaseEntity
{
    public ShippingMethod(int cost, string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }

    public void Edit(int cost, string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }
    public string Title { get; private set; }
    public int Cost { get; private set; }
}
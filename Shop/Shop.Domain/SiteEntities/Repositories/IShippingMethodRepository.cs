using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}
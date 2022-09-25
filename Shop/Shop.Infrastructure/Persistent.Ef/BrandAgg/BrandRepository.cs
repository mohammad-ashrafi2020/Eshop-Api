using Shop.Domain.BrandAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.BrandAgg;

public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ShopContext context) : base(context)
    {
    }
}
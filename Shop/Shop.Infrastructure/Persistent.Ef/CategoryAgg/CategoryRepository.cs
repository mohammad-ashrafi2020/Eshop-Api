using Common.Application.Validation;
using Shop.Domain.CategoryAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg;

internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ShopContext context) : base(context)
    {
    }
}
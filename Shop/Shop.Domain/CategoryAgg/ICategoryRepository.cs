using Common.Domain.Repository;

namespace Shop.Domain.CategoryAgg
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> DeleteCategory(long categoryId);
    }
}
using Common.Domain.Repository;

namespace Shop.Domain.SiteEntities.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        void Delete(Slider slider);
    }
}

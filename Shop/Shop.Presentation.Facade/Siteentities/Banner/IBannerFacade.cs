using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Banner;

public interface IBannerFacade
{
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);

    Task<BannerDto?> GetBannerById(long id);
    Task<List<BannerDto>> GetBanners();
}
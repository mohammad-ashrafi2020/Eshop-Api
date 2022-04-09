using Common.Application;

namespace Shop.Application.SiteEntities.Banners.Delete;

public record DeleteBannerCommand(long Id) : IBaseCommand;
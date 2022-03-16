using Common.Query;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;
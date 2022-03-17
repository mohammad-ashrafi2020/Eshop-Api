using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.Banners.GetById;
using Shop.Query.SiteEntities.Banners.GetList;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Banner;

internal class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditBanner(EditBannerCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<BannerDto?> GetBannerById(long id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));

    }

    public async Task<List<BannerDto>> GetBanners()
    {
        return await _mediator.Send(new GetBannerListQuery());

    }


}
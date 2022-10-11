using Common.AspNetCore;
using Common.ChachHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Shop.Api.ViewModels;
using Shop.Presentation.Facade.Products;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Query.Products.DTOs;

namespace Shop.Api.Controllers;

public class UtilitiesController : ApiController
{
    private IDistributedCache _distributedCache;
    private ISliderFacade _sliderFacade;
    private IBannerFacade _bannerFacade;
    private IProductFacade _productFacade;
    public UtilitiesController(IDistributedCache distributedCache, ISliderFacade sliderFacade, IBannerFacade bannerFacade, IProductFacade productFacade)
    {
        _distributedCache = distributedCache;
        _sliderFacade = sliderFacade;
        _bannerFacade = bannerFacade;
        _productFacade = productFacade;
    }

    [HttpGet("MainPageData")]
    public async Task<ApiResult<MainPageViewModel>> MainPageData()
    {
        var model = await _distributedCache.GetOrSet("mainPageData", GetMainPageData);
        return QueryResult(model);
    }


    private async Task<MainPageViewModel> GetMainPageData()
    {
        var sliders = await _sliderFacade.GetSliders();
        var banners = await _bannerFacade.GetBanners();
        var latest = await _productFacade.GetProductsForShop(new ProductShopFilterParam()
        {
            Take = 8,
            PageId = 1,
            SearchOrderBy = ProductSearchOrderBy.Latest
        });
        var hasDiscount = await _productFacade.GetProductsForShop(new ProductShopFilterParam()
        {
            Take = 8,
            PageId = 1,
            JustHasDiscount = true,
            SearchOrderBy = ProductSearchOrderBy.Latest
        });
        return new MainPageViewModel()
        {
            AmazingProducts = hasDiscount.Data,
            Banners = banners,
            LatestProduct = latest.Data,
            Sliders = sliders
        };
    }
}
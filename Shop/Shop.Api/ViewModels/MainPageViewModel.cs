using Shop.Query.Categories.DTOs;
using Shop.Query.Products.DTOs;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Api.ViewModels;

public class MainPageViewModel
{
    public List<BannerDto> Banners { get; set; }
    public List<SliderDto> Sliders { get; set; }
    public List<ProductShopDto> LatestProduct { get; set; }
    public List<ProductShopDto> AmazingProducts { get; set; }
}
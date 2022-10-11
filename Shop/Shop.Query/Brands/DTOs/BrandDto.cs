using Common.Query;

namespace Shop.Query.Brands.DTOs;

public class BrandDto : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
}
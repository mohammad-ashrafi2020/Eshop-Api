using Common.Domain.ValueObjects;
using Common.Query;
using Shop.Domain.ProductAgg;
using Shop.Query.Categories.DTOs;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Products.DTOs;

public class ProductDto : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public ProductCategoryDto Category { get; set; }
    public ProductCategoryDto SubCategory { get; set; }
    public ProductCategoryDto? SecondarySubCategory { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDto> Images { get; set; }
    public List<ProductSpecificationDto> Specifications { get; set; }
}
public class SinglePageProductDto
{
    public ProductDto ProductDto { get; set; }
    public List<InventoryDto> Inventories { get; set; }
    public int CommentsCount { get; set; }
    public string Rate { get; set; }
    public int LikePercentage { get; set; }
    public int LikeCount { get; set; }
}

public class ProductCategoryDto
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}
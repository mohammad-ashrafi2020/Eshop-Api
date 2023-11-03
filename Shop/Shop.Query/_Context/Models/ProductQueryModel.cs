using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query._Context.Models;

[Table("Products", Schema = "product")]
class ProductQueryModel : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public long? SecondarySubCategoryId { get; set; }
    public long BrandId { get; set; }
    public string Slug { get; set; }
}
[Table("Categories", Schema = "dbo")]
class CategoryQueryModel:BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string ImageName { get; set; }
    public long? ParentId { get; set; }
    public SeoData? SeoData { get; set; }
}
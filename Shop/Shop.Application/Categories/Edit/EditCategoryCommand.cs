using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id, string Title, string Slug, SeoData SeoData) : IBaseCommand;
}
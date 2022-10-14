using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string Title, string Slug, IFormFile ImageFile, SeoData SeoData) 
        : IBaseCommand<long>;
}
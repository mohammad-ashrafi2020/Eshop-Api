using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id, string Title, string Slug,IFormFile? ImageFile, SeoData SeoData) : IBaseCommand;
}
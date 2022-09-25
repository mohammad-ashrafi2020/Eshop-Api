using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Categories.Create
{
    public record CreateCategoryCommand(string Title, string Slug,IFormFile ImageFile, SeoData SeoData) 
        : IBaseCommand<long>;
}
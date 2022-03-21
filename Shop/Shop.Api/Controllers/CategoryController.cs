using Common.Application;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;

namespace Shop.Api.Controllers
{

    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _categoryFacade.GetCategories();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }
        [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
        {
            var result = await _categoryFacade.GetCategoriesByParentId(parentId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategories", "Category");
            return CreatedResult(result, $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{url}");
        }
        [HttpPost("AddChild")]
        public async Task<ApiResult> CreateCategory(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> RemoveCategory(long categoryId)
        {
            var result = await _categoryFacade.Remove(categoryId);
            return CommandResult(result);
        }
    }
}

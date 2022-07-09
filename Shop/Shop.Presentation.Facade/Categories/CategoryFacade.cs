using Common.Application;
using Common.ChachHelper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParentId;
using Shop.Query.Categories.GetList;

namespace Shop.Presentation.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;
    private IDistributedCache _cache;
    public CategoryFacade(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Remove(long categoryId)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);

        return await _mediator.Send(new RemoveCategoryCommand(categoryId));
    }

    public async Task<CategoryDto> GetCategoryById(long id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(id));
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(long parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));

    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _cache.GetOrSet(CacheKeys.Categories, () =>
        {
            return _mediator.Send(new GetCategoryListQuery());
        });
    }
}
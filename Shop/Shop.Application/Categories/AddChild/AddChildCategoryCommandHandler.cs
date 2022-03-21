using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand,long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainServicer;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer)
        {
            _repository = repository;
            _domainServicer = domainServicer;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult<long>.NotFound();

            category.AddChild(request.Title, request.Slug, request.SeoData, _domainServicer);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}
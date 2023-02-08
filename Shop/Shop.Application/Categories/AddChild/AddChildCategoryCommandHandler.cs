using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Shop.Application._Utilities;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainServicer;
        private readonly IFileService _fileService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer, IFileService fileService)
        {
            _repository = repository;
            _domainServicer = domainServicer;
            _fileService = fileService;
        }

        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult<long>.NotFound();

            if (request.ImageFile.IsImage() == false)
                return OperationResult<long>.Error("عکس نامعتبراست");

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.CategoryImages);

            category.AddChild(request.Title, request.Slug, imageName, request.SeoData, _domainServicer);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}
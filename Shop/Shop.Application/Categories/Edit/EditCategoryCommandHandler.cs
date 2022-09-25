using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Shop.Application._Utilities;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainServicer;
        private readonly IFileService _fileService;
        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer, IFileService fileService)
        {
            _repository = repository;
            _domainServicer = domainServicer;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();

            category.Edit(request.Title, request.Slug, request.SeoData, _domainServicer);
            if (request.ImageFile.IsImage())
            {
                var imageName =
                    await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.CategoryImages);
                category.SetImageName(imageName);
            }
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
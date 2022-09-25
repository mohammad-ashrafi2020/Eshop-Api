using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Shop.Application._Utilities;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainServicer;
        private readonly IFileService _fileService;
        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainServicer, IFileService fileService)
        {
            _repository = repository;
            _domainServicer = domainServicer;
            _fileService = fileService;
        }

        public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.ImageFile.IsImage() == false)
                return OperationResult<long>.Error("عکس نامعتبراست");

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.CategoryImages);
            var category = new Category(request.Title, request.Slug, request.SeoData, _domainServicer, imageName);
            _repository.Add(category);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}
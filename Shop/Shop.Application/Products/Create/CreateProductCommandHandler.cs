using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;

        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, ILocalFileService localFileService)
        {
            _domainService = domainService;
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategoryId, _domainService, request.Slug,
                request.SeoData);

            await _repository.Add(product);

            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            product.SetSpecification(specifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;

        public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository, ILocalFileService localFileService)
        {
            _domainService = domainService;
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
                request.SecondarySubCategoryId, request.Slug, _domainService, request.SeoData);

            var oldImage = product.ImageName;

            if (request.ImageFile != null)
            {
                var imageName = await _localFileService
                    .SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                product.SetProductImage(imageName);
            }
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
            await _repository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _localFileService.DeleteFile(Directories.ProductImages, oldImageName);
            }
        }
    }
}
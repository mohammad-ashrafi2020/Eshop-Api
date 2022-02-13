using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    internal class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;

        public AddProductImageCommandHandler(IProductRepository repository, ILocalFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _localFileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
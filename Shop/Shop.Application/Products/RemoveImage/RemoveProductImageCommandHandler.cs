using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage
{
    internal class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;

        public RemoveProductImageCommandHandler(IProductRepository repository, ILocalFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            await _repository.Save();
            _localFileService.DeleteFile(Directories.ProductGalleryImage, imageName);
            return OperationResult.Success();
        }
    }
}
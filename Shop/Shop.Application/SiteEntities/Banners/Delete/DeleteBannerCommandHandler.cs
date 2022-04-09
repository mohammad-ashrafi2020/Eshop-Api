using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Banners.Delete;

internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _localFileService;
    public DeleteBannerCommandHandler(IBannerRepository repository, IFileService localFileService)
    {
        _repository = repository;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner =await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        _repository.Delete(banner);
        await _repository.Save();
        _localFileService.DeleteFile(Directories.BannerImages,banner.ImageName);
        return OperationResult.Success();
    }
}
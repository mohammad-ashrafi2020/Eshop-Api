﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;
    public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();
        var imageName = banner.ImageName;
        var oldImage = banner.ImageName;
        
        if (request.ImageFile != null)
            imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

        banner.Edit(request.Link,imageName,request.Position);

        DeleteOldImage(request.ImageFile, oldImage);
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile != null)
            _fileService.DeleteFile(Directories.SliderImages, oldImage);
    }
}
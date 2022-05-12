using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommand : IBaseCommand
{
    public long Id { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Title { get; set; }
}
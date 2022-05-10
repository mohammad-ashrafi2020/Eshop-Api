using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommand : IBaseCommand
{

    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
}
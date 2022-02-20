using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommand : IBaseCommand
{
    public CreateSliderCommand(string link, IFormFile imageFile, string title)
    {
        Link = link;
        ImageFile = imageFile;
        Title = title;
    }
    public string Link { get; private set; }
    public IFormFile ImageFile { get; private set; }
    public string Title { get; private set; }
}
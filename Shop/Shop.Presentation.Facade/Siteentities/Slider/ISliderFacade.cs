using Common.Application;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacade
{
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);

    Task<SliderDto?> GetSliderById(long id);
    Task<List<SliderDto>> GetSliders();
}
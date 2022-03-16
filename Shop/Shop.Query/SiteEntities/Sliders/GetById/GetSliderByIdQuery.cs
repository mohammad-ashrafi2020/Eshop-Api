using Common.Query;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;

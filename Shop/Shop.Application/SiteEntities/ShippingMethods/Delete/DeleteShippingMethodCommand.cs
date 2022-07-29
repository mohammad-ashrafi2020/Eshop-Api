using Common.Application;

namespace Shop.Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(long Id):IBaseCommand;
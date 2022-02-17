using Common.Application;

namespace Shop.Application.Sellers.Edit;

public record EditSellerCommand(long Id, string ShopName, string NationalCode) : IBaseCommand;
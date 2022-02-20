using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.Edit;

public record EditSellerCommand(long Id, string ShopName, string NationalCode,SellerStatus Status) : IBaseCommand;
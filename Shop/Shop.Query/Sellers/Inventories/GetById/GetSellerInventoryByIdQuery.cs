using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetById;

public record GetSellerInventoryByIdQuery(long InventoryId) : IQuery<InventoryDto>;
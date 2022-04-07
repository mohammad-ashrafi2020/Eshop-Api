using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetList;

public record GetInventoriesQuery(long SellerId) : IQuery<List<InventoryDto>>;
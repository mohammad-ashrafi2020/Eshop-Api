using Common.Query;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByUserId;

public record GetSellerByUserIdQuery(long UserId) : IQuery<SellerDto?>;
using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(long ProductId) : IQuery<List<InventoryDto>>;


public class GetInventoriesByProductIdQueryHandler : IQueryHandler<GetInventoriesByProductIdQuery, List<InventoryDto>>
{
    private readonly DapperContext _context;

    public GetInventoriesByProductIdQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryDto>> Handle(GetInventoriesByProductIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _context.CreateConnection();
        var sql = $"SELECT * FROM {_context.Inventories} where ProductId=@productId";
        var result = await connection.QueryAsync<InventoryDto>(sql, new { productId = request.ProductId });
        return result.ToList();
    }
}
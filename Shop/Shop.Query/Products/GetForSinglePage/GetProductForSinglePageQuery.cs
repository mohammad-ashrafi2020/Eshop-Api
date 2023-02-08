using AngleSharp.Io;
using Common.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CommentAgg;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetBySlug;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Products.GetForSinglePage;

public class GetProductForSinglePageQuery : IQuery<SinglePageProductDto?>
{
    public GetProductForSinglePageQuery(string slug)
    {
        Slug = slug;
    }

    public string Slug { get; private set; }
}

class GetProductForSinglePageQueryHandler : IQueryHandler<GetProductForSinglePageQuery, SinglePageProductDto?>
{
    private readonly ShopContext _context;
    private readonly DapperContext _dapperContext;
    public GetProductForSinglePageQueryHandler(ShopContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<SinglePageProductDto?> Handle(GetProductForSinglePageQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Slug == request.Slug, cancellationToken);
        var model = product.Map();

        if (model == null)
            return null;


        await model.SetCategories(_context);

        var lastModel = new SinglePageProductDto()
        {
            ProductDto = model,
            Inventories = await GetInventories(model.Id)
        };
        await SetProductCommentsInfo(lastModel);
        await SetRate(lastModel);
        return lastModel;
    }
    private async Task SetProductCommentsInfo(SinglePageProductDto model)
    {
        var commentsQuery =
                _context.Comments
                    .Where(r => r.ProductId == model.ProductDto.Id && r.Status == CommentStatus.Accepted);

        model.CommentsCount = await commentsQuery.CountAsync();
        model.LikeCount = await commentsQuery.Where(r => r.UserRecommendedStatus == UserRecommendedStatus.پیشنهاد_میکنم)
            .CountAsync();

        if (model.CommentsCount == 0 || model.LikeCount == 0)
            model.LikePercentage = 0;
        else
            model.LikePercentage = ((model.LikeCount - model.CommentsCount / model.CommentsCount) * 100) + 100;
    }

    private async Task SetRate(SinglePageProductDto model)
    {
        var sql = $"select AVG(Rate) from {_dapperContext.Comments} where ProductId=@productId";
        using var sqlConnection = _dapperContext.CreateConnection();
        var res = await sqlConnection.QueryFirstAsync<decimal?>(sql, new { productId = model.ProductDto.Id });
        model.Rate = (res ?? (decimal)5.0).ToString("##.###");
    }
    private async Task<List<InventoryDto>> GetInventories(long productId)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id  
            inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE ProductId=@productId";

        var result = await connection.QueryAsync<InventoryDto>(sql, new { productId });
        return result.ToList();

    }
}
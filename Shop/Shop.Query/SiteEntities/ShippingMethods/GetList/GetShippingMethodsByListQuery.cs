using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.ShippingMethods.GetList;

public class GetShippingMethodsByListQuery : IQuery<List<ShippingMethodDto>>
{

}

internal class GetShippingMethodsByListQueryHandler : IQueryHandler<GetShippingMethodsByListQuery, List<ShippingMethodDto>>
{
    private readonly ShopContext _context;

    public GetShippingMethodsByListQueryHandler(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodsByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).ToListAsync(cancellationToken);
    }
}
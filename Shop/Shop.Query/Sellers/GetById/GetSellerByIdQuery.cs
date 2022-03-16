using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; private set; }
}
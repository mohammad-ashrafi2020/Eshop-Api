using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers;

public class SellerDomainService:ISellerDomainService
{
    public bool IsValidSellerInformation(Seller seller)
    {
        throw new NotImplementedException();
    }

    public bool NationalCodeExistInDataBase(string nationalCode)
    {
        throw new NotImplementedException();
    }
}
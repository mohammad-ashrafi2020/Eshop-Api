using Common.Application;

namespace Shop.Application.Sellers.Create;

public class CreateSellerCommand:IBaseCommand
{
    public CreateSellerCommand(long userId, string shopName, string nationalCode)
    {
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }
    public long UserId { get; private set; }
    public string ShopName { get; private set; }
    public string NationalCode { get; private set; }
}
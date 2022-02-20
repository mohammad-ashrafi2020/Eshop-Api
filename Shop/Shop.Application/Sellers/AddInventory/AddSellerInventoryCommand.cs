using Common.Application;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommand : IBaseCommand
{
    public AddSellerInventoryCommand(long sellerId, long productId, int count,
        int price, int? percentageDiscount)
    {
        SellerId = sellerId;
        ProductId = productId;
        Count = count;
        Price = price;
        PercentageDiscount = percentageDiscount;
    }
    public long SellerId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? PercentageDiscount { get; private set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Query._Context.Models;

[Table("Inventories", Schema = "seller")]
class InventoryQueryModel
{
    public long SellerId { get; set; }
    public long ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int? DiscountPercentage { get; set; }

    public SellerQueryModel Seller { get; set; }
}
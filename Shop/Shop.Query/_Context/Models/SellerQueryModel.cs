using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.SellerAgg;

namespace Shop.Query._Context.Models;

[Table("Sellers", Schema = "seller")]
class SellerQueryModel
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
    public DateTime? LastUpdate { get; set; }
    public List<InventoryQueryModel> Inventories { get; set; }
}
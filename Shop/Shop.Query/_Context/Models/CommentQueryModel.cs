using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using Common.Query;
using Shop.Domain.CommentAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.UserAgg;

namespace Shop.Query._Context.Models;


[Table("Comments")]
class CommentQueryModel : BaseDto
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public string Text { get; set; }
    public CommentStatus Status { get; set; }
    public DateTime UpdateDate { get; set; }
    public decimal Rate { get; set; }
    public string Disadvantages { get; set; }
    public string Advantages { get; set; }
    public UserRecommendedStatus UserRecommendedStatus { get; set; }


    public UserQueryModel User { get; set; }
    public ProductQueryModel Product { get; set; }
}
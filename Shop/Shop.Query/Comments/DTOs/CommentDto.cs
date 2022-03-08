using Common.Query;
using Common.Query.Filter;
using Shop.Domain.CommentAgg;

namespace Shop.Query.Comments.DTOs;

public class CommentDto : BaseDto
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public string UserFullName { get; set; }

    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public CommentStatus Status { get; set; }
}

public class CommentFilterParams : BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }

}
public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams>
{

}
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CommentAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query._Context;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly QueryContext _context;

    public GetCommentByFilterQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var result = _context.Comments
            .Include(c => c.Product)
            .Include(c => c.User)
            .OrderByDescending(d => d.CreationDate).AsQueryable();


        if (@params.ProductId != null)
            result = result.Where(r => r.UserId == @params.ProductId);

        if (@params.CommentStatus != null)
            result = result.Where(r => r.Status == @params.CommentStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);



        var skip = (@params.PageId - 1) * @params.Take;
        var res = await result.Skip(skip).Take(@params.Take)
            .ToListAsync(cancellationToken);

        var data = res.Select(comment => new CommentDto
        {
            Id = comment.Id,
            CreationDate = comment.CreationDate,
            ProductId = comment.ProductId,
            UserId = comment.UserId,
            UserFullName = $"{comment.User.Name} {comment.User.Family}",
            ProductTitle = comment.Product.Title,
            Text = comment.Text,
            Status = comment.Status,
            Disadvantages = comment.Disadvantages.Split('-'),
            Advantages = comment.Advantages.Split("-"),
            UserRecommendedStatus = comment.UserRecommendedStatus,
            Rate = comment.Rate
        }).ToList();
        var model = new CommentFilterResult()
        {
            Data = data,
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}
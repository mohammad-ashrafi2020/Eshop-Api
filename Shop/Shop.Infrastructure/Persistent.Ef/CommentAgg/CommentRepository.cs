using Shop.Domain.CommentAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ShopContext context) : base(context)
    {
    }
}
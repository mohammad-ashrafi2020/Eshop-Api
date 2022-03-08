using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById;

public record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto?>;
using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Delete;

public record DeleteCommentCommand(long CommentId,long UserId) : IBaseCommand;


public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _repository;

    public DeleteCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId);
        if(comment == null || comment.UserId!=request.UserId)
            return OperationResult.NotFound();

        await _repository.DeleteAndSave(comment);
        return OperationResult.Success();
    }
}

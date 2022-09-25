using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.ProductId, request.Text, request.Rate
                , request.UserRecommendedStatus, request.Advantages, request.Disadvantages);
            _repository.Add(comment);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
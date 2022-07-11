using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;

namespace Shop.Presentation.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);
    Task<OperationResult> DeleteComment(DeleteCommentCommand command);


    Task<CommentDto?> GetCommentById(long id);
    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
}
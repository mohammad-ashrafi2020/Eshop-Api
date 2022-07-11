using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Domain.CommentAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;

namespace Shop.Api.Controllers;


public class CommentController : ApiController
{
    private readonly ICommentFacade _commentFacade;

    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }

    [PermissionChecker(Permission.Comment_Management)]
    [HttpGet]
    public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentsByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("productComments")]
    public async Task<ApiResult<CommentFilterResult>> GetProductComments(int pageId = 1, int take = 10, int productId = 0)
    {
        var result = await _commentFacade.GetCommentsByFilter(new CommentFilterParams()
        {
            ProductId = productId,
            PageId = pageId,
            Take = take,
            CommentStatus = CommentStatus.Accepted
        });
        return QueryResult(result);
    }

    [PermissionChecker(Permission.Comment_Management)]
    [HttpGet("{commentId}")]
    public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);
        return QueryResult(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ApiResult> CreateComment(CreateCommentCommand command)
    {
        var result = await _commentFacade.CreateComment(command);
        return CommandResult(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _commentFacade.EditComment(command);
        return CommandResult(result);
    }

    [HttpPut("changeStatus")]
    [PermissionChecker(Permission.Comment_Management)]
    public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
    {
        var result = await _commentFacade.ChangeStatus(command);
        return CommandResult(result);
    }

    [HttpDelete("{commentId}")]
    [Authorize]
    public async Task<ApiResult> DeleteComment(long commentId)
    {
        var result = await _commentFacade.DeleteComment(new DeleteCommentCommand(commentId, User.GetUserId()));
        return CommandResult(result);
    }
}
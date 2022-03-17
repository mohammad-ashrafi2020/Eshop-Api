using Common.Application;
using MediatR;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;
using Shop.Query.Roles.GetById;
using Shop.Query.Roles.GetList;

namespace Shop.Presentation.Facade.Roles;

internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateRole(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditRole(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<RoleDto?> GetRoleById(long roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    }
    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
}
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Roles;
using Shop.Query.Roles.DTOs;

namespace Shop.Api.Controllers;


[PermissionChecker(Permission.Role_Management)]
public class RoleController : ApiController
{
    private readonly IRoleFacade _roleFacade;

    public RoleController(IRoleFacade roleFacade)
    {
        _roleFacade = roleFacade;
    }

    [HttpGet]
    public async Task<ApiResult<List<RoleDto>>> GetRoles()
    {
        var result = await _roleFacade.GetRoles();
        return QueryResult(result);
    }

    [HttpGet("{roleId}")]
    public async Task<ApiResult<RoleDto?>> GetRoleById(long roleId)
    {
        var result = await _roleFacade.GetRoleById(roleId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _roleFacade.CreateRole(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditRole(EditRoleCommand command)
    {
        var result = await _roleFacade.EditRole(command);
        return CommandResult(result);
    }
}
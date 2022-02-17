using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
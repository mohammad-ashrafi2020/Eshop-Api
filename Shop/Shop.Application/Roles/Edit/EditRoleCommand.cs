using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Edit;

public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;
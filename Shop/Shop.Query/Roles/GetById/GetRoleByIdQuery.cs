using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;
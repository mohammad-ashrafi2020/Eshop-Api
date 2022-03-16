using Common.Query;
using Shop.Domain.RoleAgg;

namespace Shop.Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}
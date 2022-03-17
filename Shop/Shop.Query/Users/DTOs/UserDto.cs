using Common.Query;
using Common.Query.Filter;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Query.Users.DTOs;

public class UserDto:BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
    public List<UserRoleDto> Roles { get; set; }
}
public class UserRoleDto
{
    public long RoleId { get; set; }
    public string RoleTitle { get; set; }
}


public class UserFilterData : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
}

public class UserFilterParams:BaseFilterParam
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public long? Id { get; set; }
}
public class UserFilterResult : BaseFilter<UserFilterData,UserFilterParams>
{

}
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }

    public long UserId { get; private set; }
}
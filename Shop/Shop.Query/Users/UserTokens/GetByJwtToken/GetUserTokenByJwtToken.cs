using Common.Query;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Query.Users.UserTokens.GetByJwtToken;

public record GetUserTokenByJwtTokenQuery(string HashJwtToken) : IQuery<UserTokenDto?>;
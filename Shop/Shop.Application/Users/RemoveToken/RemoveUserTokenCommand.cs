using Common.Application;

namespace Shop.Application.Users.RemoveToken;

public record RemoveUserTokenCommand(long UserId,long TokenId) : IBaseCommand<string>;
using System.Net.Http.Headers;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.ChangePassword;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Application.Users.RemoveToken;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.GetByFilter;
using Shop.Query.Users.GetById;
using Shop.Query.Users.GetByPhoneNumber;
using Shop.Query.Users.UserTokens;
using Shop.Query.Users.UserTokens.GetByJwtToken;
using Shop.Query.Users.UserTokens.GetByRefreshToken;

namespace Shop.Presentation.Facade.Users;

internal class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _distributedCache;
    public UserFacade(IMediator mediator, IDistributedCache distributedCache)
    {
        _mediator = mediator;
        _distributedCache = distributedCache;
    }


    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<string>> RemoveToken(RemoveUserTokenCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
        {
            await _distributedCache.RemoveAsync(CacheKeys.Token(result.Data));
        }

        return result;
    }

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
            await _distributedCache.RemoveAsync(CacheKeys.SingleUser(command.UserId));

        return result;
    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
            await _distributedCache.RemoveAsync(CacheKeys.SingleUser(command.UserId));

        return result;
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        return await _distributedCache.GetOrSet(CacheKeys.SingleUser(userId),
            () => _mediator.Send(new GetUserByIdQuery(userId)), new CacheOptions()
            {
                AbsoluteExpirationCacheFromMinutes = 5,
                ExpireSlidingCacheFromMinutes = 2
            });
    }

    public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
        return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
    }

    public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        var hashJwtToken = Sha256Hasher.Hash(jwtToken);
        return await _distributedCache.GetOrSet(CacheKeys.Token(hashJwtToken), () =>
        {
            return _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        });
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}
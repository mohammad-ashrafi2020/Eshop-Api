using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers;

public class AuthController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IConfiguration _configuration;
    public AuthController(IUserFacade userFacade, IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ApiResult<string?>> Login(LoginViewModel loginViewModel)
    {
        var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
        if (user == null)
        {
            var result = OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }

        if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
        {
            var result = OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }

        if (user.IsActive == false)
        {
            var result = OperationResult<string>.Error("حساب کاربری شما غیرفعال است");
            return CommandResult(result);
        }

        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        return new ApiResult<string?>()
        {
            Data = token,
            IsSuccess = true,
            MetaData = new()
        };
    }

    [HttpPost("register")]
    public async Task<ApiResult> Register(RegisterViewModel register)
    {
        var command = new RegisterUserCommand(new PhoneNumber(register.PhoneNumber), register.Password);
        var result = await _userFacade.RegisterUser(command);
        return CommandResult(result);
    }
}
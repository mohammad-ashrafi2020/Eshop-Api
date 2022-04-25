using Common.Application;

namespace Shop.Application.Users.ChangePassword;

public class ChangeUserPasswordCommand : IBaseCommand
{
    public long UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
}
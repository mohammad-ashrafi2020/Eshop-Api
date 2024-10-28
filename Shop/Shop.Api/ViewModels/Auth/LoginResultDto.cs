namespace Shop.Api.ViewModels.Auth;

public class LoginResultDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public bool IsAdmin { get; set; }
}
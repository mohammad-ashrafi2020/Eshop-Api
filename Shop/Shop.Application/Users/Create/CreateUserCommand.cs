using System.Data;
using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Create;

public class CreateUserCommand : IBaseCommand
{
    public CreateUserCommand(string name, string family, string phoneNumber, string email, string password, Gender gender)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
}
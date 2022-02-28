using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

public class EditUserAddressCommand : IBaseCommand
{
    public EditUserAddressCommand(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family, string nationalCode, long userId)
    {
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        UserId = userId;
    }

    public long UserId { get; private set; }
    public long Id { get; set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }

}

internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _repository;

    public EditUserAddressCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user =await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address= new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
            request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        user.EditAddress(address,request.Id);
        await _repository.Save();

        return OperationResult.Success();
    }
}
using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Users.DTOs;

public class AddressDto:BaseDto
{
    public long UserId { get;  set; }
    public string Shire { get;  set; }
    public string City { get;  set; }
    public string PostalCode { get;  set; }
    public string PostalAddress { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Name { get;  set; }
    public string Family { get;  set; }
    public string NationalCode { get;  set; }
    public bool ActiveAddress { get;  set; }
}
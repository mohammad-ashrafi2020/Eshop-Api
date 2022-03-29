using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetList;

public record GetUserAddressesListQuery(long UserId) : IQuery<List<AddressDto>>;
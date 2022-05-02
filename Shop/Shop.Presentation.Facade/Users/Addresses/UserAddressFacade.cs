using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.Addresses.GetList;
using Shop.Query.Users.DTOs;

namespace Shop.Presentation.Facade.Users.Addresses
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<AddressDto?> GetById(long userAddressId)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));

        }

        public async Task<List<AddressDto>> GetList(long userId)
        {
            return await _mediator.Send(new GetUserAddressesListQuery(userId));
        }

        public async Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
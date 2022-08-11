using Common.Application;
using MediatR;

namespace Shop.Application.Orders.Finally;

public record OrderFinallyCommand(long OrderId) : IBaseCommand;
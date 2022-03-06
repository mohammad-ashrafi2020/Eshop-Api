using MediatR;

namespace Common.Query;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
{

}
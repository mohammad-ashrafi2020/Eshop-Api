namespace Shop.Infrastructure._Utilities.MediatR;

public interface ICustomPublisher
{
    Task Publish<TNotification>(TNotification notification);
    Task Publish<TNotification>(TNotification notification, PublishStrategy strategy);
    Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken);
    Task Publish<TNotification>(TNotification notification, PublishStrategy strategy, CancellationToken cancellationToken);
}
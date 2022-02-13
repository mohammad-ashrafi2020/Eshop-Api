using Common.Application;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}
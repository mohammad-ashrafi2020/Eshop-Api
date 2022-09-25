using Common.Domain;
using Common.Domain.ValueObjects;

namespace Shop.Domain.BrandAgg;

public class Brand : AggregateRoot
{
    public Brand(string imageName, string title)
    {
        ImageName = imageName;
        Title = title;
    }

    public string Title { get; private set; }
    public string ImageName { get; private set; }
}
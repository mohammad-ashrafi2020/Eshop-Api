namespace Shop.Presentation.Facade;

public class CacheKeys
{
    public static string SingleUser(long id) => $"usr-{id}";
    public static string Token(string token) => $"t-{token}";

    public static string SingleProduct(string slug) => $"product-{slug}";
    public static string Categories = "categories";
}
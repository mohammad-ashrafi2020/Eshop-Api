using AngleSharp;
using AspNetCoreRateLimit;
using Shop.Api.Infrastructure.Gateways.Zibal;
using Shop.Api.Infrastructure.JwtUtil;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Shop.Api.Infrastructure;

public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddAutoMapper(typeof(MapperProfile).Assembly);
        service.AddTransient<CustomJwtValidation>();
        service.AddHttpClient<IZibalService, ZibalService>();
        service.AddTransient<DataSeeder>();
        service.AddCors(options =>
        {
            options.AddPolicy(name: "ShopApi",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });
        service.AddMemoryCache();
    }
}
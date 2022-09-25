using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef;
using QueryContext = Shop.Query._Context.QueryContext;

namespace Shop.Query;

public class QueryBootstrapper
{
    public static void Init(IServiceCollection services,string connectionString)
    {
        services.AddDbContext<QueryContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}
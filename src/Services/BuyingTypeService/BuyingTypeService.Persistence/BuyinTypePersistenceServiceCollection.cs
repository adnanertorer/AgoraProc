using System.Reflection;
using BuyingTypeService.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyingTypeService.Persistence;

public static class BuyinTypePersistenceServiceCollection
{
    public static IServiceCollection AddBuyinTypePersistenceServiceCollection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BuyingTypeDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
            options.UseNpgsql(connectionStrings!.DefaultConnection, m => m.MigrationsAssembly(Assembly.GetExecutingAssembly()));
        });

        return services;
    }
}

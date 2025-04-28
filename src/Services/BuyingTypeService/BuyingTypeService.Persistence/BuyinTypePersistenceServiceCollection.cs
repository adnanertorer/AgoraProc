using System.Reflection;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Persistence.Repositories;
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
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"), m => m.MigrationsAssembly("BuyingTypeService.API"));
            
        });
        services.AddScoped<IBuyingTypeRepository, BuyingTypeRepository>();
        return services;
    }
}

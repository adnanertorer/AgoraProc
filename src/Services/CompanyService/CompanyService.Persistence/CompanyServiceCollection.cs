using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyService.Persistence;

public static class CompanyServiceCollection
{
    public static IServiceCollection AddCompanyService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CompanyDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"),
                m => m.MigrationsAssembly("CompanyService.API"));
        });
        return services;
    }
}
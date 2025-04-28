using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuyingTypeService.Persistence;

public class BuyingTypeDbContextFactory : IDesignTimeDbContextFactory<BuyingTypeDbContext>
{
    public BuyingTypeDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../BuyingTypeService.API");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BuyingTypeDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"));

        return new BuyingTypeDbContext(optionsBuilder.Options);
    }
}

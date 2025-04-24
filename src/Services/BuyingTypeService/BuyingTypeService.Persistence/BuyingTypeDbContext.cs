using System.Reflection;
using BuyingTypeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyingTypeService.Persistence;

public class BuyingTypeDbContext(DbContextOptions<BuyingTypeDbContext> options):DbContext(options)
{
    public DbSet<BuyingType> BuyingTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

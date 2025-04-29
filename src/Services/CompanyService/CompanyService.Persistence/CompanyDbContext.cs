using System.Reflection;
using CompanyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Persistence;

public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<Company>  Companies { get; set; }
    public DbSet<MainService>  MainServices { get; set; }
    public DbSet<Domain.Entities.CompanyService> CompanyService { get; set; }
    public DbSet<CustomerService>  CustomerServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
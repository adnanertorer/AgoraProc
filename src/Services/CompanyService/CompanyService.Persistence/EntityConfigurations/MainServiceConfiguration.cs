using CompanyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyService.Persistence.EntityConfigurations;

public class MainServiceConfiguration : IEntityTypeConfiguration<MainService>
{
    public void Configure(EntityTypeBuilder<MainService> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TenantId)
            .IsRequired();
        builder.Property(i => i.MainServiceName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(i => i.MainServiceCode)
            .IsRequired()
            .HasMaxLength(10);
        
        builder.Property(c => c.UpdatedBy).HasMaxLength(64);
        builder.Property(c => c.DeletedBy).HasMaxLength(64);
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(64);
        builder.Property(c => c.CreatedDate).IsRequired();
        
        builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CompanyServiceEntity = CompanyService.Domain.Entities.CompanyService;   

namespace CompanyService.Persistence.EntityConfigurations;


public class CompanyServiceConfiguration : IEntityTypeConfiguration<CompanyServiceEntity>
{
    public void Configure(EntityTypeBuilder<CompanyServiceEntity> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.CustomerServiceId)
            .IsRequired();
        builder.Property(i => i.CompanyId)
            .IsRequired();
        builder.Property(i => i.MainServiceId)
            .IsRequired();
        
        builder.Property(c => c.UpdatedBy).HasMaxLength(64);
        builder.Property(c => c.DeletedBy).HasMaxLength(64);
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(64);
        builder.Property(c => c.CreatedDate).IsRequired();
        
        builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
    }
}
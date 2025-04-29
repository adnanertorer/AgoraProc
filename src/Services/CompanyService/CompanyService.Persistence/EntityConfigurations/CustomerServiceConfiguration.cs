using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyService.Persistence.EntityConfigurations;
using CustomerServiceEntity = CompanyService.Domain.Entities.CustomerService;

public class CustomerServiceConfiguration : IEntityTypeConfiguration<CustomerServiceEntity>
{
    public void Configure(EntityTypeBuilder<CustomerServiceEntity> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.MainServiceId)
            .IsRequired();
        builder.Property(i => i.ServiceCode)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(i => i.ServiceName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(c => c.UpdatedBy).HasMaxLength(64);
        builder.Property(c => c.DeletedBy).HasMaxLength(64);
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(64);
        builder.Property(c => c.CreatedDate).IsRequired();
        
        builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
    }
}
using BuyingTypeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuyingTypeService.Persistence.EntityConfigurations;

public class BuyingTypeConfiguration : IEntityTypeConfiguration<BuyingType>
{
    public void Configure(EntityTypeBuilder<BuyingType> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TenantId)
           .IsRequired();
        builder.Property(i => i.BuyingTypeName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(i => i.CreatedDate)
          .IsRequired();
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(64);

        builder.Property(c => c.UpdatedBy).HasMaxLength(64);
        builder.Property(c => c.DeletedBy).HasMaxLength(64);

        builder.HasQueryFilter(c => c.IsDeleted == false || c.DeletedDate == null);
    }
}

using CompanyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyService.Persistence.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TenantId)
            .IsRequired();
        builder.Property(i => i.AuthorizedPerson)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(i => i.CompanyDescription)
            .HasMaxLength(250);
        builder.Property(i => i.CompanyFile)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(i => i.CompanyName)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(i => i.CompanyPhone)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(i => i.Gsm)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(i => i.IsActive)
            .IsRequired();
        builder.Property(i => i.OtpCode)
            .HasMaxLength(6);
        builder.Property(i => i.Password)
            .IsRequired()
            .HasMaxLength(64);
        builder.Property(i => i.RefreshToken)
            .HasMaxLength(50);
        builder.Property(i => i.VatNumber)
            .IsRequired()
            .HasMaxLength(16);
        builder.Property(i => i.VatOffice)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(c => c.UpdatedBy).HasMaxLength(64);
        builder.Property(c => c.DeletedBy).HasMaxLength(64);
        builder.Property(c => c.CreatedBy).IsRequired().HasMaxLength(64);
        builder.Property(c => c.CreatedDate).IsRequired();
        
        builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
    }
}
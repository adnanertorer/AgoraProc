using Adoroid.Core.Repository.Repositories;

namespace BuyingTypeService.Domain.Entities;

public class BuyingType : Entity<long>
{
    public long TenantId { get; set; }
    public string BuyingTypeName { get; set; } = default!;
}

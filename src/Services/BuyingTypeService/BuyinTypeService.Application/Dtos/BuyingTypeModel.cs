namespace BuyingTypeService.Application.Dtos;

public class BuyingTypeModel
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string BuyingTypeName { get; set; } = default!;
}

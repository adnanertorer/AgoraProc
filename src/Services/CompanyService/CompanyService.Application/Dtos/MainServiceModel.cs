namespace CompanyService.Application.Dtos;

public class MainServiceModel
{
    public long TenantId { get; set; }
    public string MainServiceName { get; set; } = null!;
    public string MainServiceCode { get; set; } = null!;
    
    public List<CompanyServiceModel>?  CompanyServices { get; set; }
    public List<CustomerServiceModel>?  CustomerServices { get; set; }
}
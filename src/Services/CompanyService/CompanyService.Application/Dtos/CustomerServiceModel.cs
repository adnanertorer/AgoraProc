using CompanyService.Domain.Entities;

namespace CompanyService.Application.Dtos;

public class CustomerServiceModel
{
    public long MainServiceId { get; set; }
    public string ServiceCode { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    
    public MainService? MainService { get; set; }
    public List<CompanyServiceModel>?  CompanyServiceModels { get; set; }
}
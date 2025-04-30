namespace CompanyService.Application.Dtos;

public class CustomerServiceModel
{
    public long Id { get; set; }
    public long MainServiceId { get; set; }
    public string ServiceCode { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    
    public MainServiceModel? MainService { get; set; }
    public List<CompanyServiceModel>?  CompanyServiceModels { get; set; }
}
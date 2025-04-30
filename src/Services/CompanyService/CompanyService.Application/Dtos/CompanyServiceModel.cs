namespace CompanyService.Application.Dtos;

public class CompanyServiceModel
{
    public long Id { get; set; }
    public long CustomerServiceId { get; set; }
    public long CompanyId { get; set; }
    public long MainServiceId { get; set; }
    
    public CompanyModel? Company { get; set; }
    public List<CustomerServiceModel>? CustomerServices { get; set; }
}
using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class MainService : Entity<long>
{
    public MainService()
    {
        CompanyServices = new HashSet<CompanyService>();
        CustomerServices = new HashSet<CustomerService>();
    }
    public long TenantId { get; set; }
    public string MainServiceName { get; set; }
    public string MainServiceCode { get; set; }

    public virtual ICollection<CompanyService> CompanyServices { get; set; }
    public virtual ICollection<CustomerService> CustomerServices { get; set; }
}

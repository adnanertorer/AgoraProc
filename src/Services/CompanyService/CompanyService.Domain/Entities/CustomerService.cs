using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class CustomerService : Entity<long>
{
    public CustomerService()
    {
        CompanyServices = new HashSet<CompanyService>();
    }
    public long MainServiceId { get; set; }
    public string ServiceCode { get; set; } = default!;
    public string ServiceName { get; set; } = default!;

    public virtual MainService? MainService { get; set; }
    public virtual ICollection<CompanyService> CompanyServices { get; set; }
}

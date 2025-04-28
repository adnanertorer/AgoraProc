using System.ComponentModel.DataAnnotations.Schema;
using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class CompanyService : Entity<long>
{
    public long CustomerServiceId { get; set; }
    public long CompanyId { get; set; }
    public long MainServiceId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public virtual Company? Company { get; set; }

    [ForeignKey(nameof(MainServiceId))]
    public virtual MainService? MainService { get; set; }

    [ForeignKey(nameof(CustomerServiceId))]
    public virtual CustomerService? CustomerService { get; set; }
}

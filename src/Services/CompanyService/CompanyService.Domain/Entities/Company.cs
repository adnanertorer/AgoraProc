using System.ComponentModel.DataAnnotations.Schema;
using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class Company : Entity<long>
{

    public Company()
    {
        CompanyServices = new HashSet<CompanyService>();
    }

    public long TenantId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyDescription { get; init; }
    public string CompanyPhone { get; init; }
    public string Gsm { get; init; }
    public string AuthorizedPersonFirstName { get; init; }
    public string AuthorizedPersonLastName { get; init; }
    public bool IsActive { get; init; }
    public string? CompanyFile { get; init; }
    public bool? IsInBlackList { get; init; }
    public bool? Canceled { get; init; }
    public string VatNumber { get; init; } 
    public string VatOffice { get; init; }

    public virtual ICollection<CompanyService> CompanyServices { get; init; }
}

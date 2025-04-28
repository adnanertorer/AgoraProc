using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class Company : Entity<long>
{

    public Company()
    {
        CompanyServices = new HashSet<CompanyService>();
    }

    public long TenantId { get; set; }
    public string CompanyName { get; set; } = default!;
    public string CompanyDescription { get; set; } = default!;
    public string CompanyPhone { get; set; } = default!;
    public string Gsm { get; set; } = default!;
    public string AuthorizedPerson { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public string? OTPCode { get; set; }
    public string? CompanyFile { get; set; }
    public bool? IsInBlackList { get; set; }
    public bool? Canceled { get; set; }

    public virtual ICollection<CompanyService> CompanyServices { get; set; }
}

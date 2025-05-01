using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Domain.Entities;

public class Company : Entity<long>
{

    public Company()
    {
        CompanyServices = new HashSet<CompanyService>();
    }

    public long TenantId { get; init; }
    public string CompanyName { get; init; } = null!;
    public string CompanyDescription { get; init; } = null!;
    public string CompanyPhone { get; init; } = null!;
    public string Gsm { get; init; } = null!;
    public string AuthorizedPerson { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public bool IsActive { get; init; }
    public string? RefreshToken { get; init; }
    public DateTime? RefreshTokenEndDate { get; init; }
    public string? OtpCode { get; init; }
    public string? CompanyFile { get; init; }
    public bool? IsInBlackList { get; init; }
    public bool? Canceled { get; init; }
    public string VatNumber { get; init; } = null!;
    public string VatOffice { get; init; } = null!;

    public virtual ICollection<CompanyService> CompanyServices { get; init; }
}

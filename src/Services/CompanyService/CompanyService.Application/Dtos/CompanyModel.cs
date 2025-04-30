namespace CompanyService.Application.Dtos;

public class CompanyModel
{
    public long Id { get; set; }
    public long TenantId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string CompanyDescription { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;
    public string Gsm { get; set; } = null!;
    public string AuthorizedPerson { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? CompanyFile { get; set; }
}
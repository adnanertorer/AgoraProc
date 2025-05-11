namespace AuthService.Configs;

public class AuthenticationInfo
{
    public string Authority { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public bool RequireHttpsMetadata { get; set; }
}
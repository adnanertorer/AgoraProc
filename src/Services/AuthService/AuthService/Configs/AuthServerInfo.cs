namespace AuthService.Configs;

public class AuthServerInfo
{
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
    public string AuthServerUrl { get; set; } = null!;
    public string HostName { get; set; } = null!;
    public string Realm { get; set; } = null!;
}
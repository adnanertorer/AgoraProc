namespace AuthService.Services.Abstracts;

public interface ICurrentUserService
{
    string? Id { get; }
    string? UserName { get; }
    string? Email { get; }
    string? Token { get; }
    List<string>? Roles { get; }
}
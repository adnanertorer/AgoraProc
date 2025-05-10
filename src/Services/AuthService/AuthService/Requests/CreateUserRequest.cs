namespace AuthService.Requests;

public record CreateUserRequest(string Username, string Password, string Email, string FirstName, string LastName, bool IsActive,
    string? AuthId);
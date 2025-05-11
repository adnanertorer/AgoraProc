namespace AuthService.Requests;


public record RegisterRequest(string Username, string FirstName,
    string LastName, string Email, string Password, bool Enabled, bool EmailVerified,
    bool Temporary, string PhoneNumber, long? CompanyId);
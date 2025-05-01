namespace CompanyService.Application.ExeptionMessages;

public static class ValidationMessages
{
    private static string MaximumCharacterWarning(string name, int length){
        return $"The maximum character length for {name} must be {length} characters";
    }
    private static string MustBeGreaterThan(string name, int lenght){
        return $"{name} must be grater than {lenght}";
    }
    public static readonly string TenantIdMustBeGreaterThanZero = MustBeGreaterThan("Tenant id", 0);
    public const string AuthorizedPersonCannotBeEmpty = "Authorized person cannot be empty";
    public static readonly string AuthorizedPersonMaxCharacter = MaximumCharacterWarning("authorized person", 150);
    public const string CompanyDescriptionCannotBeEmpty = "Company description cannot be empty";
    public static readonly string CompanyDescriptionMaxCharacter = MaximumCharacterWarning("company description", 250);
    public const string CompanyNameCannotBeEmpty = "Company name cannot be empty";
    public static readonly string CompanyNameMaxCharacter = MaximumCharacterWarning("company name", 150);
    public const string EmailCannotBeEmpty = "Email cannot be empty";
    public static readonly string EmailMaximumCharacter = MaximumCharacterWarning("email", 50);
    public const string PhoneCannotBeEmpty = "Phone cannot be empty";
    public static readonly string PhoneMaximumCharacter = MaximumCharacterWarning("phone", 20);
    public const string GsmCannotBeEmpty = "Gsm cannot be empty";
    public static readonly string GsmMaximumCharacter = MaximumCharacterWarning("gsm", 20);
    public static readonly string CustomerServiceIdMustBeGreaterThanZero = MustBeGreaterThan("Customer service id", 0);
    public static readonly string CompanyIdMustBeGreaterThanZero = MustBeGreaterThan("Customer id", 0);
    public static readonly string MainServiceIdMustBeGreaterThanZero = MustBeGreaterThan("Main service id", 0);
    public const string ServiceCodeCannotBeEmpty = "Service code cannot be empty";
    public static readonly string ServiceCodeMaximumCharacter = MaximumCharacterWarning("service code", 10);
    public const string ServiceNameCannotBeEmpty = "Service name cannot be empty";
    public static readonly string ServiceNameMaximumCharacter = MaximumCharacterWarning("service name", 50);
    public const string PasswordCannotBeEmpty = "Password cannot be empty";
    public static readonly string PasswordMaximumCharacter = MaximumCharacterWarning("password", 20);
    public const string VatNumberCannotBeEmpty = "VAT number cannot be empty";
    public static readonly string VatNumberMaximumCharacter = MaximumCharacterWarning("vat number", 20);
    public const string VatOfficeCannotBeEmpty = "VAT office cannot be empty";
    public static readonly string VatOfficeMaximumCharacter = MaximumCharacterWarning("vat office", 150);
}
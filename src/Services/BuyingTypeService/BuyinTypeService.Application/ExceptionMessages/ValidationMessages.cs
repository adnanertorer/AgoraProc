namespace BuyingTypeService.Application.ExceptionMessages;

public class ValidationMessages
{
    public const string BuyingTypeObjectCannotBeNull = "BuyingType object cannot be null";
    public const string NameCannotBeEmptyOrNull = "Name cannot be empty or null";
    public const string NameMustBeAtMost = "Name must be at most 49 characters";
    public const string TenantIdMusBeGreatherThenZero = "Tenant id must be greather than zero";
    public const string IdMusBeGreaterThenZero = "Id must be greater than zero";
    public const string PageRequestRequired = "Page request required";
    public const string PageRequestPageSizeMustBeGreaterThanZero = "Page size must be greater than 0.";
    public const string PageRequestPageSizeMustBeLessThan100 = "Page size must be less than 100.";
}

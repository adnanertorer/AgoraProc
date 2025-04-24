namespace BuyingTypeService.Application.ExceptionMessages;

public class ValidationMessages
{
    public const string BuyingTypeObjectCannotBeNull = "BuyingType object cannot be null";
    public const string NameCannotBeEmptyOrNull = "Name cannot be empty or null";
    public const string NameMustBeAtMost = "Name must be at most 49 characters";
    public const string TenantIdMusBeGreatherThenZero = "Tenant id must be greather than zero";
    public const string IdMusBeGreatherThenZero = "Id must be greather than zero";
}

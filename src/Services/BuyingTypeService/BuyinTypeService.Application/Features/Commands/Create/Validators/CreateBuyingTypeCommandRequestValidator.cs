using BuyingTypeService.Application.ExceptionMessages;
using FluentValidation;

namespace BuyingTypeService.Application.Features.Commands.Create.Validators;

public class CreateBuyingTypeCommandRequestValidator : AbstractValidator<CreateBuyingTypeCommandRequest>
{
    public CreateBuyingTypeCommandRequestValidator()
    {
        RuleFor(x => x.BuyingType).NotNull().WithMessage(ValidationMessages.BuyingTypeObjectCannotBeNull);
        RuleFor(x => x.BuyingType.BuyingTypeName)
            .NotEmpty().WithMessage(ValidationMessages.NameCannotBeEmptyOrNull)
            .MaximumLength(49).WithMessage(ValidationMessages.NameMustBeAtMost)
            .When(x => x.BuyingType != null);

        RuleFor(x => x.BuyingType.TenantId).GreaterThan(0)
            .WithMessage(ValidationMessages.TenantIdMusBeGreatherThenZero)
            .When(x => x.BuyingType != null);
    }
}

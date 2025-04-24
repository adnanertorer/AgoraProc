using BuyingTypeService.Application.ExceptionMessages;
using FluentValidation;

namespace BuyingTypeService.Application.Features.Queries.GetList.Validators;

public class GetBuyingTypeListRequestValidator : AbstractValidator<GetBuyingTypeListRequest>
{
    public GetBuyingTypeListRequestValidator()
    {
        RuleFor(i => i.PageRequest).NotNull()
        .WithMessage(ValidationMessages.PageRequestRequired);

        RuleFor(i => i.PageRequest.PageSize)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.PageRequestPageSizeMustBeGreaterThanZero)
            .LessThan(100)
            .WithMessage(ValidationMessages.PageRequestPageSizeMustBeLessThan100);
    }
}

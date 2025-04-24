using BuyingTypeService.Application.ExceptionMessages;
using FluentValidation;

namespace BuyingTypeService.Application.Features.Queries.GetById.Validators;

public class GetBuyingTypeByIdRequestValidator : AbstractValidator<GetBuyingTypeByIdRequest>
{
    public GetBuyingTypeByIdRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ValidationMessages.IdMusBeGreatherThenZero);
    }
}

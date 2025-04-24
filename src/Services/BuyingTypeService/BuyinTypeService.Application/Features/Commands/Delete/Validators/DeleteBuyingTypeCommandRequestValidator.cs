using BuyingTypeService.Application.ExceptionMessages;
using FluentValidation;

namespace BuyingTypeService.Application.Features.Commands.Delete.Validators;

public class DeleteBuyingTypeCommandRequestValidator : AbstractValidator<DeleteBuyingTypeCommandRequest>
{
    public DeleteBuyingTypeCommandRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ValidationMessages.IdMusBeGreatherThenZero);
    }
}

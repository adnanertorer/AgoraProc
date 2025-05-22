using CompanyService.Application.ExeptionMessages;
using FluentValidation;

namespace CompanyService.Application.Features.Company.Commands.Delete.Validators;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ValidationMessages.IdMusBeGreaterThenZero);
    }
}
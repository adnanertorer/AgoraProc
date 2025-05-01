using CompanyService.Application.ExeptionMessages;
using FluentValidation;

namespace CompanyService.Application.Features.Company.Commands.Create.Validators;

public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
{
    public CreateCompanyRequestValidator()
    {
        RuleFor(i => i.TenantId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.TenantIdMustBeGreaterThanZero);

        RuleFor(i => i.CompanyName)
            .NotEmpty()
            .WithMessage(ValidationMessages.CompanyNameCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.CompanyNameCannotBeEmpty)
            .MaximumLength(150)
            .WithMessage(ValidationMessages.CompanyNameMaxCharacter);
        
        RuleFor(i => i.CompanyDescription)
            .NotEmpty()
            .WithMessage(ValidationMessages.CompanyDescriptionCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.CompanyDescriptionCannotBeEmpty)
            .MaximumLength(150)
            .WithMessage(ValidationMessages.CompanyDescriptionMaxCharacter);
        
        RuleFor(i => i.CompanyPhone)
            .NotEmpty()
            .WithMessage(ValidationMessages.PhoneCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.PhoneCannotBeEmpty)
            .MaximumLength(20)
            .WithMessage(ValidationMessages.PhoneMaximumCharacter);
        
        RuleFor(i => i.Gsm)
            .NotEmpty()
            .WithMessage(ValidationMessages.GsmCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.GsmCannotBeEmpty)
            .MaximumLength(20)
            .WithMessage(ValidationMessages.GsmMaximumCharacter);
        
        RuleFor(i => i.AuthorizedPerson)
            .NotEmpty()
            .WithMessage(ValidationMessages.AuthorizedPersonCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.AuthorizedPersonCannotBeEmpty)
            .MaximumLength(150)
            .WithMessage(ValidationMessages.AuthorizedPersonMaxCharacter);
        
        RuleFor(i => i.Email)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmailCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.EmailCannotBeEmpty)
            .MaximumLength(50)
            .WithMessage(ValidationMessages.EmailMaximumCharacter);
        
        RuleFor(i => i.Password)
            .NotEmpty()
            .WithMessage(ValidationMessages.PasswordCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.PasswordCannotBeEmpty)
            .MaximumLength(50)
            .WithMessage(ValidationMessages.PasswordMaximumCharacter);
        
        RuleFor(i => i.VatNumber)
            .NotEmpty()
            .WithMessage(ValidationMessages.VatNumberCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.VatNumberCannotBeEmpty)
            .MaximumLength(20)
            .WithMessage(ValidationMessages.VatNumberMaximumCharacter);
        
        RuleFor(i => i.VatOffice)
            .NotEmpty()
            .WithMessage(ValidationMessages.VatOfficeCannotBeEmpty)
            .NotNull()
            .WithMessage(ValidationMessages.VatOfficeCannotBeEmpty)
            .MaximumLength(150)
            .WithMessage(ValidationMessages.VatOfficeMaximumCharacter);
    }
}
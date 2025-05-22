using Adoroid.Core.Application.Wrappers;
using CompanyService.Application.Dtos;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Create;

public record CreateCompanyRequest(long TenantId, string CompanyName, string CompanyDescription,
    string CompanyPhone, string Gsm, string FirstName, string LastName, string Email, string Password, string? CompanyFile,
    string VatNumber, string VatOffice): IRequest<Response<CompanyModel>>;
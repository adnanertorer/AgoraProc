using CompanyService.Application.Dtos;
using CompanyService.Application.Wrappers;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Create;

public record CreateCompanyRequest(long TenantId, string CompanyName, string CompanyDescription,
    string CompanyPhone, string Gsm, string AuthorizedPerson, string Email, string Password, string? CompanyFile,
    string VatNumber, string VatOffice): IRequest<ResponseResult<CompanyModel>>;
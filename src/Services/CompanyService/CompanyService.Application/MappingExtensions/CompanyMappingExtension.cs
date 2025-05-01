using CompanyService.Application.Dtos;
using CompanyService.Application.Features.Company.Commands.Create;
using CompanyService.Domain.Entities;

namespace CompanyService.Application.MappingExtensions;

public static class CompanyMappingExtension
{
    public static CompanyModel ToModel(this Company company)
    {
        return new CompanyModel
        {
            AuthorizedPerson = company.AuthorizedPerson,
            CompanyDescription = company.CompanyDescription,
            CompanyName = company.CompanyName,
            CompanyFile = company.CompanyFile,
            CompanyPhone = company.CompanyPhone,
            Email = company.Email,
            Gsm = company.Gsm,
            TenantId = company.TenantId,
            Id = company.Id
        };
    }

    public static Company ToEntityRequest(this CreateCompanyRequest model)
    {
        return new Company
        {
            AuthorizedPerson = model.AuthorizedPerson,
            CompanyDescription = model.CompanyDescription,
            CompanyName = model.CompanyName,
            CompanyFile = model.CompanyFile,
            CompanyPhone = model.CompanyPhone,
            Email = model.Email,
            Gsm = model.Gsm,
            TenantId = model.TenantId
        };
    }

    public static Company ToEntity(this CompanyModel model)
    {
        return new Company
        {
            AuthorizedPerson = model.AuthorizedPerson,
            CompanyDescription = model.CompanyDescription,
            CompanyName = model.CompanyName,
            CompanyFile = model.CompanyFile,
            CompanyPhone = model.CompanyPhone,
            Email = model.Email,
            Gsm = model.Gsm,
            TenantId = model.TenantId,
            Id = model.Id
        };
    }
}
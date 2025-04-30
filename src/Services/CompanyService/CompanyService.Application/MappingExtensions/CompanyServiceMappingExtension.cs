using CompanyService.Application.Dtos;

namespace CompanyService.Application.MappingExtensions;

public static class CompanyServiceMappingExtension
{
    public static CompanyServiceModel ToDto(this Domain.Entities.CompanyService companyService)
    {
        return new CompanyServiceModel
        {
            Company = new CompanyModel
            {
                CompanyName = companyService.Company!.CompanyName,
                Id = companyService.Company!.Id,
            },
            CompanyId = companyService.CompanyId,
            CustomerServiceId = companyService.CustomerServiceId,
            MainServiceId = companyService.MainServiceId,
            Id = companyService.Id
        };
    }

    public static Domain.Entities.CompanyService ToEntity(this CompanyServiceModel model)
    {
        return new Domain.Entities.CompanyService
        {
            CompanyId = model.CompanyId,
            CustomerServiceId = model.CustomerServiceId,
            Id = model.Id,
            MainServiceId = model.MainServiceId
        };
    }
}
using CompanyService.Application.Dtos;
using CompanyService.Domain.Entities;

namespace CompanyService.Application.MappingExtensions;

public static class MainServiceMappingExtension
{
    public static MainServiceModel ToDto(this MainService entity)
    {
        return new MainServiceModel
        {
            Id = entity.Id,
            MainServiceCode = entity.MainServiceCode,
            MainServiceName = entity.MainServiceName,
            TenantId = entity.TenantId
        };
    }

    public static MainService ToEntity(this MainServiceModel dto)
    {
        return new MainService
        {
            Id = dto.Id,
            MainServiceCode = dto.MainServiceCode,
            TenantId = dto.TenantId,
            MainServiceName = dto.MainServiceName
        };
    }
}
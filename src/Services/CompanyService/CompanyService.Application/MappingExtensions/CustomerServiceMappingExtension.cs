using CompanyService.Application.Dtos;
using CompanyService.Domain.Entities;

namespace CompanyService.Application.MappingExtensions;

public static class CustomerServiceMappingExtension
{
    public static CustomerServiceModel ToDto(this CustomerService entity)
    {
        return new CustomerServiceModel
        {
            MainServiceId = entity.MainServiceId,
            ServiceCode = entity.ServiceCode,
            ServiceName = entity.ServiceName,
            Id = entity.Id,
            MainService = new  MainServiceModel
            {
                Id = entity.MainServiceId,
                MainServiceCode = entity.MainService!.MainServiceCode,
                MainServiceName = entity.MainService!.MainServiceName
            }
        };
    }

    public static CustomerService ToEntity(this CustomerServiceModel dto)
    {
        return new CustomerService
        {
            MainServiceId = dto.MainServiceId,
            Id = dto.Id,
            ServiceCode = dto.ServiceCode,
            ServiceName = dto.ServiceName
        };
    }
}
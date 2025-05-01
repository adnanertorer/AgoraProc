using CompanyService.Application.Abstracts;
using CompanyService.Application.Dtos;
using CompanyService.Application.ExeptionMessages;
using CompanyService.Application.MappingExtensions;
using CompanyService.Application.Wrappers;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Create;

public class CreateCompanyRequestHandler(ICompanyRepository  repository) : IRequestHandler<CreateCompanyRequest, ResponseResult<CompanyModel>>
{
    public async Task<ResponseResult<CompanyModel>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var isExist = await repository.AnyAsync(
            i => i.VatNumber == request.VatNumber && i.VatOffice == request.VatOffice,
            cancellationToken: cancellationToken);

        if (isExist)
            return ResponseResult<CompanyModel>.Fail(BusinessMessages.CompanyIsAlreadyExists);

        var entity = request.ToEntityRequest();
        entity.CreatedBy = "system";
        entity.CreatedDate = DateTime.UtcNow;
        
        var resultEntity = await repository.AddAsync(entity);
        
        return ResponseResult<CompanyModel>.Success(resultEntity.ToModel());
    }
}
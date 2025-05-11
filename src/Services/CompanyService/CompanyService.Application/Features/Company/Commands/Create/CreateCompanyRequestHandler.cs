using AuthService.Abstracts;
using AuthService.Requests;
using AuthService.Services.Abstracts;
using CompanyService.Application.Abstracts;
using CompanyService.Application.Dtos;
using CompanyService.Application.ExeptionMessages;
using CompanyService.Application.MappingExtensions;
using CompanyService.Application.Wrappers;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Create;

public class CreateCompanyRequestHandler(ICompanyRepository  repository, 
    ICurrentUserService currentUserService, IAuthService authService) : IRequestHandler<CreateCompanyRequest, ResponseResult<CompanyModel>>
{
    public async Task<ResponseResult<CompanyModel>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var isExist = await repository.AnyAsync(
            i => i.VatNumber == request.VatNumber && i.VatOffice == request.VatOffice,
            cancellationToken: cancellationToken);

        if (isExist)
            return ResponseResult<CompanyModel>.Fail(BusinessMessages.CompanyIsAlreadyExists);

        var entity = request.ToEntityRequest();
        entity.CreatedBy = currentUserService.Id;
        entity.CreatedDate = DateTime.UtcNow;
        
        var resultEntity = await repository.AddAsync(entity);
        var registerRequest = new RegisterRequest(request.Email, request.FirstName, request.LastName, request.Email,
            request.Password, true, true, false, request.Gsm, resultEntity.Id);
        await authService.Register(registerRequest, cancellationToken);
        
        return ResponseResult<CompanyModel>.Success(resultEntity.ToModel());
    }
}
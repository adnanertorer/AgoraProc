using Adoroid.Core.Application.Wrappers;
using AuthService.Abstracts;
using AuthService.Requests;
using AuthService.Services.Abstracts;
using CompanyService.Application.Abstracts;
using CompanyService.Application.Dtos;
using CompanyService.Application.ExeptionMessages;
using CompanyService.Application.MappingExtensions;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Create;

public class CreateCompanyRequestHandler(ICompanyRepository  repository, 
    ICurrentUserService currentUserService, IAuthService authService) : IRequestHandler<CreateCompanyRequest, Response<CompanyModel>>
{
    public async Task<Response<CompanyModel>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var isExist = await repository.AnyAsync(
            i => i.VatNumber == request.VatNumber && i.VatOffice == request.VatOffice,
            cancellationToken: cancellationToken);

        if (isExist)
            return Response<CompanyModel>.Fail(BusinessMessages.CompanyIsAlreadyExists);

        var entity = request.ToEntityRequest();
        entity.CreatedBy = currentUserService.Id;
        entity.CreatedDate = DateTime.UtcNow;
        
        var resultEntity = await repository.AddAsync(entity);
        var registerRequest = new RegisterRequest(request.Email, request.FirstName, request.LastName, request.Email,
            request.Password, true, true, false, request.Gsm, resultEntity.Id);
        await authService.Register(registerRequest, cancellationToken);
        
        return Response<CompanyModel>.Success(resultEntity.ToModel());
    }
}
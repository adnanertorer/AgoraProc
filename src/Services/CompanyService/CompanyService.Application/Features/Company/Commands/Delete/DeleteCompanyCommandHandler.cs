using Adoroid.Core.Application.Wrappers;
using AuthService.Services.Abstracts;
using CompanyService.Application.Abstracts;
using CompanyService.Application.Dtos;
using CompanyService.Application.ExeptionMessages;
using CompanyService.Application.MappingExtensions;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Delete;

public class DeleteCompanyCommandHandler(ICompanyRepository  repository, 
    ICurrentUserService currentUserService) : IRequestHandler<DeleteCompanyCommand, Response<CompanyModel>>
{
    public async Task<Response<CompanyModel>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await repository.GetAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

        if (company is null)
            return Response<CompanyModel>.Fail(BusinessMessages.CompanyNotFound);
        
        company.IsDeleted = true;
        company.DeletedBy = currentUserService.Id;
        company.DeletedDate = DateTime.UtcNow;
        
        await repository.UpdateAsync(company);
        
        return Response<CompanyModel>.Success(company.ToModel());
    }
}
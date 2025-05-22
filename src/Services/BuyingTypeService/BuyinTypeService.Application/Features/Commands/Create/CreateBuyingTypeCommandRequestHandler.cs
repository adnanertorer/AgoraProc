using Adoroid.Core.Application.Wrappers;
using AuthService.Services.Abstracts;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.InformationMessages;
using BuyingTypeService.Domain.Entities;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Create;

public class CreateBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository, 
    ICurrentUserService currentUserService) : IRequestHandler<CreateBuyingTypeCommandRequest, Response<BuyingTypeModel>>
{
    public async Task<Response<BuyingTypeModel>> Handle(CreateBuyingTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var isExist = await buyingTypeRepository.AnyAsync(predicate: i => i.TenantId == request.BuyingType.TenantId
        && i.BuyingTypeName == request.BuyingType.BuyingTypeName, cancellationToken: cancellationToken);

        if (isExist)
        {
            return Response<BuyingTypeModel>.Fail(BusinessMessages.BuyinTypeIsAlreadyExists);
        }
        
        var entity = new BuyingType
        {
            BuyingTypeName = request.BuyingType.BuyingTypeName,
            TenantId = request.BuyingType.TenantId,
            CreatedBy = currentUserService.Id,
            CreatedDate = DateTime.UtcNow,
            IsDeleted = false
        };

        var resultEntity = await buyingTypeRepository.AddAsync(entity);

        var model = new BuyingTypeModel
        {
            TenantId = resultEntity.TenantId,
            BuyingTypeName = resultEntity.BuyingTypeName,
            Id = resultEntity.Id
        };

        return Response<BuyingTypeModel>.Success(model, InfoMessages.BuyingTypeCreatedSuccessfully);
    }
}

using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.InformationMessages;
using BuyingTypeService.Application.Wrappers;
using BuyingTypeService.Domain.Entities;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Create;

public class CreateBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository) : IRequestHandler<CreateBuyingTypeCommandRequest, ResponseResult<BuyingTypeModel>>
{
    public async Task<ResponseResult<BuyingTypeModel>> Handle(CreateBuyingTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var isExist = await buyingTypeRepository.AnyAsync(predicate: i => i.TenantId == request.BuyingType.TenantId
        && i.BuyingTypeName == request.BuyingType.BuyingTypeName, cancellationToken: cancellationToken);

        if (isExist)
        {
            return ResponseResult<BuyingTypeModel>.Fail(BusinessMessages.BuyinTypeIsAlreadyExists);
        }

        var entity = new BuyingType
        {
            BuyingTypeName = request.BuyingType.BuyingTypeName,
            TenantId = request.BuyingType.TenantId,
            CreatedBy = "system",
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

        return ResponseResult<BuyingTypeModel>.Success(model, InfoMessages.BuyingTypeCreatedSuccessfully);
    }
}

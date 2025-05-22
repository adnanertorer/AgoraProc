using Adoroid.Core.Application.Wrappers;
using AuthService.Services.Abstracts;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.InformationMessages;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Update;

public class UpdateBuyingTypeCommandRequest : IRequest<Response<BuyingTypeModel>>
{
    public required BuyingTypeModel BuyingType {  get; set; }
}

public class UpdateBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository,
    ICurrentUserService currentUserService) : IRequestHandler<UpdateBuyingTypeCommandRequest, Response<BuyingTypeModel>>
{
    public async Task<Response<BuyingTypeModel>> Handle(UpdateBuyingTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.BuyingType.Id, cancellationToken: cancellationToken);
        if (model == null)
        {
            return Response<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
        }

        model.UpdatedDate = DateTime.UtcNow;
        model.UpdatedBy = currentUserService.Id;
        model.BuyingTypeName = request.BuyingType.BuyingTypeName;

        await buyingTypeRepository.UpdateAsync(model);


        return Response<BuyingTypeModel>.Success(new BuyingTypeModel
        { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId }, InfoMessages.BuyingTypeUpdatedSuccessfully);
    }
}

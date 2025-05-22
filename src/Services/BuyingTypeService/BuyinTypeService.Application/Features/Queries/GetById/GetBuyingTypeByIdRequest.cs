using Adoroid.Core.Application.Wrappers;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Queries.GetById;

public class GetBuyingTypeByIdRequest : IRequest<Response<BuyingTypeModel>>
{
    public long Id { get; set; }
}

public class GetBuyingTypeByIdRequestHandler(IBuyingTypeRepository buyingTypeRepository) 
    : IRequestHandler<GetBuyingTypeByIdRequest, Response<BuyingTypeModel>>
{
    public async Task<Response<BuyingTypeModel>> Handle(GetBuyingTypeByIdRequest request, CancellationToken cancellationToken)
    {
        var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
        if (model == null)
        {
            return Response<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
        }

        return Response<BuyingTypeModel>.Success(new BuyingTypeModel
        { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId });
    }
}

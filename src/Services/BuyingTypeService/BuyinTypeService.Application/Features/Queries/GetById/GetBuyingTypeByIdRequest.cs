using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.Wrappers;
using MediatR;

namespace BuyingTypeService.Application.Features.Queries.GetById;

public class GetBuyingTypeByIdRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
    public long Id { get; set; }

    public class GetBuyingTypeByIdRequestHandler(IBuyingTypeRepository buyingTypeRepository) : IRequestHandler<GetBuyingTypeByIdRequest, ResponseResult<BuyingTypeModel>>
    {
        public async Task<ResponseResult<BuyingTypeModel>> Handle(GetBuyingTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            if (model == null)
            {
                return ResponseResult<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
            }

            return ResponseResult<BuyingTypeModel>.Success(new BuyingTypeModel
            { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId });
        }
    }
}

using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.InformationMessages;
using BuyingTypeService.Application.Wrappers;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Update;

public class UpdateBuyingTypeCommandRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
    public required BuyingTypeModel BuyingType {  get; set; }

    public class UpdateBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository) : IRequestHandler<UpdateBuyingTypeCommandRequest, ResponseResult<BuyingTypeModel>>
    {
        public async Task<ResponseResult<BuyingTypeModel>> Handle(UpdateBuyingTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.BuyingType.Id, cancellationToken: cancellationToken);
            if (model == null)
            {
                return ResponseResult<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
            }

            model.UpdatedDate = DateTime.UtcNow;
            model.UpdatedBy = "system";
            model.BuyingTypeName = request.BuyingType.BuyingTypeName;


            return ResponseResult<BuyingTypeModel>.Success(new BuyingTypeModel
            { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId }, InfoMessages.BuyingTypeUpdatedSuccessfully);
        }
    }
}

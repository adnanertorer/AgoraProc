using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.Wrappers;
using MediatR;

namespace BuyingTypeService.Application.Features.Commands.Delete;

public class DeleteBuyingTypeCommandRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
    public long Id { get; set; }

    public class DeleteBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository) : IRequestHandler<DeleteBuyingTypeCommandRequest, ResponseResult<BuyingTypeModel>>
    {
        public async Task<ResponseResult<BuyingTypeModel>> Handle(DeleteBuyingTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.Id);
            if (model == null) {
                return ResponseResult<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
            }

            model.DeletedDate = DateTime.UtcNow;
            model.DeletedBy = "system";
            model.IsDeleted = true;

            var entity = await buyingTypeRepository.UpdateAsync(model);

            return ResponseResult<BuyingTypeModel>.Success(new BuyingTypeModel 
            { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId }, "Buying type deleted successfully.");
        }
    }
}

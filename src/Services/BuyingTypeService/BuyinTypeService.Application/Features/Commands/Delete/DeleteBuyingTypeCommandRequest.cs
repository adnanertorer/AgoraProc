using Adoroid.Core.Application.Wrappers;
using AuthService.Services.Abstracts;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.ExceptionMessages;
using BuyingTypeService.Application.InformationMessages;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Delete;

public class DeleteBuyingTypeCommandRequest : IRequest<Response<BuyingTypeModel>>
{
    public long Id { get; set; }
}

public class DeleteBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository,
    ICurrentUserService currentUserService) : IRequestHandler<DeleteBuyingTypeCommandRequest, Response<BuyingTypeModel>>
{
    public async Task<Response<BuyingTypeModel>> Handle(DeleteBuyingTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var model = await buyingTypeRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
        if (model == null)
        {
            return Response<BuyingTypeModel>.Fail(BusinessMessages.BuyingTypeNotFound);
        }

        model.DeletedDate = DateTime.UtcNow;
        model.DeletedBy = currentUserService.Id;
        model.IsDeleted = true;

        var entity = await buyingTypeRepository.UpdateAsync(model);

        return Response<BuyingTypeModel>.Success(new BuyingTypeModel
        { Id = model.Id, BuyingTypeName = model.BuyingTypeName, TenantId = model.TenantId }, InfoMessages.BuyingTypeDeletedSuccessfully);
    }
}

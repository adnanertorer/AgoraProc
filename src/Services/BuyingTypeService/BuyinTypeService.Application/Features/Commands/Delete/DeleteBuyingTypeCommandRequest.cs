using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.Wrappers;
using MediatR;

namespace BuyingTypeService.Application.Features.Commands.Delete;

public class DeleteBuyingTypeCommandRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
    public long Id { get; set; }

    public class DeleteBuyingTypeCommandRequestHandler(IBuyingTypeRepository buyingTypeRepository) : IRequestHandler<DeleteBuyingTypeCommandRequest, ResponseResult<BuyingTypeModel>>
    {
        public Task<ResponseResult<BuyingTypeModel>> Handle(DeleteBuyingTypeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

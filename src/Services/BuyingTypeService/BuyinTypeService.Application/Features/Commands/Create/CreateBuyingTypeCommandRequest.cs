using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.Wrappers;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Create;

public class CreateBuyingTypeCommandRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
    public required BuyingTypeModel BuyingType { get; set; }

}



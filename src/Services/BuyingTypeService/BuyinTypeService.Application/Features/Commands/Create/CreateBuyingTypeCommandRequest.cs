using Adoroid.Core.Application.Wrappers;
using BuyingTypeService.Application.Dtos;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Commands.Create;

public class CreateBuyingTypeCommandRequest : IRequest<Response<BuyingTypeModel>>
{
    public required BuyingTypeModel BuyingType { get; set; }

}



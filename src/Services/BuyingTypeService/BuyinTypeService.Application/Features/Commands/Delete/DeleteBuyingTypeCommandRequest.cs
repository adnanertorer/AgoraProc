using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyingTypeService.Application.Dtos;
using BuyingTypeService.Application.Wrappers;
using MediatR;

namespace BuyingTypeService.Application.Features.Commands.Delete;

public class DeleteBuyingTypeCommandRequest : IRequest<ResponseResult<BuyingTypeModel>>
{
}

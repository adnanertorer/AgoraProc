using Microsoft.AspNetCore.Mvc;
using MinimalMediatR.Core;

namespace BuyingTypeService.API.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}

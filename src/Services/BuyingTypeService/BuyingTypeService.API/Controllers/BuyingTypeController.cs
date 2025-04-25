using BuyingTypeService.Application.Features.Commands.Create;
using BuyingTypeService.Application.Features.Commands.Delete;
using BuyingTypeService.Application.Features.Commands.Update;
using BuyingTypeService.Application.Features.Queries.GetById;
using BuyingTypeService.Application.Features.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using MinimalMediatR.Core;
using MinimalMediatR.Extensions;

namespace BuyingTypeService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuyingTypeController : BaseController
{
    public BuyingTypeController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetBuyingTypeListRequest request)
    {
        return Ok(value: await Mediator.Send(request));
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get([FromRoute] long id)
    {
        var request = new GetBuyingTypeByIdRequest { Id = id };
        return Ok(value: await Mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBuyingTypeCommandRequest createCommand)
    {
        return Ok(value: await Mediator.Send(createCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBuyingTypeCommandRequest updateCommand)
    {
        return Ok(value: await Mediator.Send(updateCommand));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        DeleteBuyingTypeCommandRequest getQuery = new() { Id = id };
        return Ok(value: await Mediator.Send(getQuery));
    }
}

using Adoroid.Core.Application.Requests;
using Adoroid.Core.Application.Wrappers;
using Adoroid.Core.Repository.Paging;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using MinimalMediatR.Core;

namespace BuyingTypeService.Application.Features.Queries.GetList;

public class GetBuyingTypeListRequest : IRequest<Response<Paginate<BuyingTypeModel>>>
{
    public string? Name { get; set; }
    public required PageRequest PageRequest { get; set; }
}

public class GetBuyingTypeListRequestHandler(IBuyingTypeRepository buyingTypeRepository) :
    IRequestHandler<GetBuyingTypeListRequest, Response<Paginate<BuyingTypeModel>>>
{
    public async Task<Response<Paginate<BuyingTypeModel>>> Handle(GetBuyingTypeListRequest request, CancellationToken cancellationToken)
    {
        var query = buyingTypeRepository.Query().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(i => i.BuyingTypeName == request.Name);
        }

        var result = await query.OrderByDescending(i => i.BuyingTypeName).Select(x => new BuyingTypeModel
        {
            BuyingTypeName = x.BuyingTypeName,
            Id = x.Id,
            TenantId = x.TenantId,
        }).ToPaginateAsync(request.PageRequest.PageIndex, request.PageRequest.PageSize, cancellationToken);

        return Response<Paginate<BuyingTypeModel>>.Success(result);
    }
}

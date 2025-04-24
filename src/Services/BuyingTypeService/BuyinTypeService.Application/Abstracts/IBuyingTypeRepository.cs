using Adoroid.Core.Repository.Repositories;
using BuyingTypeService.Domain.Entities;

namespace BuyingTypeService.Application.Abstracts;

public interface IBuyingTypeRepository : IAsyncRepository<BuyingType, long>
{
}

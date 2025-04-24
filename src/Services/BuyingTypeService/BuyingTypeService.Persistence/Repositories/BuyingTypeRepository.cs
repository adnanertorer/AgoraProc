using Adoroid.Core.Repository.Repositories;
using BuyingTypeService.Application.Abstracts;
using BuyingTypeService.Domain.Entities;

namespace BuyingTypeService.Persistence.Repositories;

public class BuyingTypeRepository(BuyingTypeDbContext context) : RepositoryBase<BuyingType, long, BuyingTypeDbContext>(context), IBuyingTypeRepository
{
}

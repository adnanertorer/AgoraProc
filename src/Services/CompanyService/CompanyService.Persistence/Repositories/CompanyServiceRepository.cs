using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Persistence.Repositories;

public class CompanyServiceRepository(CompanyDbContext dbContext) : RepositoryBase<Domain.Entities.CompanyService, long, CompanyDbContext>(dbContext)
{
    
}
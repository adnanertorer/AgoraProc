using Adoroid.Core.Repository.Repositories;
using CompanyService.Application.Abstracts;
using CompanyService.Domain.Entities;

namespace CompanyService.Persistence.Repositories;

public class CompanyRepository(CompanyDbContext dbContext) : RepositoryBase<Company, long,  CompanyDbContext>(context:dbContext), ICompanyRepository
{
    
}
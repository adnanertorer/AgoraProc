using Adoroid.Core.Repository.Repositories;

namespace CompanyService.Application.Abstracts;

public interface ICompanyServiceRepository : IAsyncRepository<CompanyService.Domain.Entities.CompanyService, long>
{
    
}
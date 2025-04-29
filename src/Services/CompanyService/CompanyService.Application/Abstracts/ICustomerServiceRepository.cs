using Adoroid.Core.Repository.Repositories;
using CompanyService.Domain.Entities;

namespace CompanyService.Application.Abstracts;

public interface ICustomerServiceRepository : IAsyncRepository<CustomerService, long>
{
    
}
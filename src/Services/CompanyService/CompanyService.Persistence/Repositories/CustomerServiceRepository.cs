using Adoroid.Core.Repository.Repositories;
using CompanyService.Application.Abstracts;

namespace CompanyService.Persistence.Repositories;

public class CustomerServiceRepository(CompanyDbContext context)
    : RepositoryBase<Domain.Entities.CustomerService, long, CompanyDbContext>(context), ICustomerServiceRepository;
using Adoroid.Core.Repository.Repositories;
using CompanyService.Application.Abstracts;
using CompanyService.Domain.Entities;

namespace CompanyService.Persistence.Repositories;

public class MainServiceRepository(CompanyDbContext context)
    : RepositoryBase<MainService, long, CompanyDbContext>(context), IMainServiceRepository;
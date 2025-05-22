using Adoroid.Core.Application.Wrappers;
using CompanyService.Application.Dtos;
using MinimalMediatR.Core;

namespace CompanyService.Application.Features.Company.Commands.Delete;

public record DeleteCompanyCommand(long Id) : IRequest<Response<CompanyModel>>;
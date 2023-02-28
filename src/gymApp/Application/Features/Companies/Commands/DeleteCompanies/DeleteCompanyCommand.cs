using Application.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<DeleteCompanyDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };
        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeleteCompanyDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly CompanyBusinessRules _companyBusinessRules;
            private readonly IMapper _mapper;

            public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _companyBusinessRules = companyBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteCompanyDto> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                await _companyBusinessRules.CompanyNotAlreadyExists(request.Id);

                Company? mappedCompany = _mapper.Map<Company>(request);

                Company deleteCompany = await _companyRepository.DeleteAsync(mappedCompany);

                DeleteCompanyDto deleteCompanyDto = _mapper.Map<DeleteCompanyDto>(deleteCompany);

                return deleteCompanyDto;
            }
        }
    }
}

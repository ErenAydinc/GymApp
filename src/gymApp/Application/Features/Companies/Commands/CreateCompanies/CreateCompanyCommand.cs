using Application.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CreateCompanyDto>,ISecuredRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly CompanyBusinessRules _companyBusinessRules;
            private readonly IMapper _mapper;

            public CreateCompanyCommandHandler(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _companyBusinessRules = companyBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateCompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                Company mappedCompany = _mapper.Map<Company>(request);

                Company createCompany = await _companyRepository.AddAsync(mappedCompany);

                CreateCompanyDto createCompanyDto = _mapper.Map<CreateCompanyDto>(createCompany);

                return createCompanyDto;
            }
        }
    }
}

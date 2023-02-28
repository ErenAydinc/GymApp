using Application.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand:IRequest<UpdateCompanyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly CompanyBusinessRules _companyBusinessRules;
            private readonly IMapper _mapper;

            public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _companyBusinessRules = companyBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdateCompanyDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                await _companyBusinessRules.CompanyNotAlreadyExists(request.Id);
                await _companyBusinessRules.CompanyAlreadyExists(request.Id);
                
                Company? mappedCompany = _mapper.Map<Company>(request);

                Company updateCompany = await _companyRepository.UpdateAsync(mappedCompany);

                UpdateCompanyDto updateCompanyDto =_mapper.Map<UpdateCompanyDto>(updateCompany);

                return updateCompanyDto;
            }
        }
    }
}

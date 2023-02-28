using Application.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery:IRequest<GetCompanyByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };
        public class GetCompanyByIdQueryHandler:IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdDto>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly CompanyBusinessRules _companyBusinessRules;
            private readonly IMapper _mapper;

            public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _companyBusinessRules = companyBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetCompanyByIdDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
            {
                await _companyBusinessRules.CompanyNotAlreadyExists(request.Id);

                Company? company= await _companyRepository.GetAsync(x => x.Id == request.Id);

                GetCompanyByIdDto getCompanyByIdDto = _mapper.Map<GetCompanyByIdDto>(company);

                return getCompanyByIdDto;
            }
        }
    }
}

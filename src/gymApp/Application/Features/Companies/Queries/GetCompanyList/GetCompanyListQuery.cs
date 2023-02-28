using Application.Constants;
using Application.Features.Companies.Constants;
using Application.Features.Companies.Models;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetCompanyList
{
    public class GetCompanyListQuery:IRequest<CompanyListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, CompanyListModel>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IUserRepository _userRepository;
            private readonly CompanyBusinessRules _companyBusinessRules;
            private readonly IMapper _mapper;

            public GetCompanyListQueryHandler(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _companyRepository = companyRepository;
                _companyBusinessRules = companyBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<CompanyListModel> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Company> company = await _companyRepository.GetListAsync(index: request.PageRequest.Page -1, size: request.PageRequest.PageSize);
                CompanyListModel mappedCompanyListModel = _mapper.Map<CompanyListModel>(company);
                return mappedCompanyListModel;
            }
        }
    }
}

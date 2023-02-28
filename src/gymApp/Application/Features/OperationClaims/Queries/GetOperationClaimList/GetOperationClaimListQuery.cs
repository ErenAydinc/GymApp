using Application.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetOperationClaimList
{
    public class GetOperationClaimListQuery:IRequest<OperationClaimListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin
        };


        public class GetOperationClaimListQueryHandler : IRequestHandler<GetOperationClaimListQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public GetOperationClaimListQueryHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<OperationClaimListModel> Handle(GetOperationClaimListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaim = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page-1, size: request.PageRequest.PageSize);

                OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaim);

                return mappedOperationClaimListModel;
            }
        }
    }
}

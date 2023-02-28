using Application.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetOperationClaimById
{
    public class GetOperationClaimByIdQuery : IRequest<GetOperationClaimByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin
        };

        public class GetOperationClaimByIdQueryHandler : IRequestHandler<GetOperationClaimByIdQuery, GetOperationClaimByIdDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public GetOperationClaimByIdQueryHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetOperationClaimByIdDto> Handle(GetOperationClaimByIdQuery request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNotExists(request.Id);

                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);

                GetOperationClaimByIdDto getOperationClaimByIdDto = _mapper.Map<GetOperationClaimByIdDto>(operationClaim);

                return getOperationClaimByIdDto;
            }
        }
    }
}

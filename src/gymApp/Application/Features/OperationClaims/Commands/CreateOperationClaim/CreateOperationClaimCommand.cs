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

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand:IRequest<CreateOperationClaimDto>,ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            OperationClaimRoles.OperationClaimAdmin,
            OperationClaimRoles.OperationClaimCreate
        };
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimAlreadyExists(request.Name);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                OperationClaim createOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);

                CreateOperationClaimDto createOperationClaimDto = _mapper.Map<CreateOperationClaimDto>(createOperationClaim);

                return createOperationClaimDto;
            }
        }
    }
}

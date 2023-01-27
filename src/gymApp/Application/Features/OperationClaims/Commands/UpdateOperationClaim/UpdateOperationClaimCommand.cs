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

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdateOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            OperationClaimRoles.OperationClaimAdmin,
            OperationClaimRoles.OperationClaimUpdate
        };

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdateOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNotExists(request.Id);
                await _operationClaimBusinessRules.OperationClaimAlreadyExists(request.Name);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                OperationClaim updateOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);

                UpdateOperationClaimDto updateOperationClaimDto = _mapper.Map<UpdateOperationClaimDto>(updateOperationClaim);

                return updateOperationClaimDto;
            }
        }
    }
}

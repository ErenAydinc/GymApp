using Application.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
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

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeleteUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
        };
        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeleteUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimNotExists(request.Id);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);

                UserOperationClaim deleteUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);

                DeleteUserOperationClaimDto deleteUserOperationClaimDto = _mapper.Map<DeleteUserOperationClaimDto>(deleteUserOperationClaim);

                return deleteUserOperationClaimDto;
            }
        }
    }
}

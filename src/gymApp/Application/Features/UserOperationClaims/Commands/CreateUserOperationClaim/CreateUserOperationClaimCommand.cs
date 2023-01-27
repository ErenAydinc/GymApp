using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public int[] OperationClaimId { get; set; }

        public string[] Roles { get; } =
        {
            UserOperationClaimRoles.UserOperationClaimCreate,
            UserOperationClaimRoles.UserOperationClaimAdmin
        };

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserNotExists(request.UserId);

                foreach (var item in request.OperationClaimId)
                {
                    UserOperationClaim userOperationClaim = new()
                    {
                        OperationClaimId = item,
                        UserId = request.UserId
                    };
                    UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaim);
                    UserOperationClaim createUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                    //CreateUserOperationClaimDto createUserOperationClaimDto =
                    _mapper.Map<CreateUserOperationClaimDto>(createUserOperationClaim);
                }

                throw new BusinessException("User operation claim added");



            }
        }
    }
}

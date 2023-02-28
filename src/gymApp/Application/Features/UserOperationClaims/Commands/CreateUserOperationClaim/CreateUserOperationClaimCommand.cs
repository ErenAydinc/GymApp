using Application.Constants;
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
        public int[] OperationClaimIds { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
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
                IList<CreateUserOperationClaimDto> userOperationClaims=new List<CreateUserOperationClaimDto>();
                foreach (var item in request.OperationClaimIds)
                {
                    IList<UserOperationClaim> deleteUserOperationClaims = await _userOperationClaimRepository.GetAllAsync(x => x.UserId == request.UserId && x.OperationClaimId == item);
                    if (deleteUserOperationClaims.Count > 0)
                    {
                        foreach (var deleteUserOperationClaim in deleteUserOperationClaims)
                        {
                            await _userOperationClaimRepository.DeleteAsync(deleteUserOperationClaim);
                        }
                    }
                    else
                    {
                        UserOperationClaim userOperationClaim = new()
                        {
                            OperationClaimId = item,
                            UserId = request.UserId
                        };
                        UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaim);
                        UserOperationClaim createUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                        //CreateUserOperationClaimDto createUserOperationClaimDto =
                        CreateUserOperationClaimDto createUserOperationClaimDto = _mapper.Map<CreateUserOperationClaimDto>(createUserOperationClaim);

                        userOperationClaims.Add(createUserOperationClaimDto);
                    }
                }
                return userOperationClaims.First();



            }
        }
    }
}

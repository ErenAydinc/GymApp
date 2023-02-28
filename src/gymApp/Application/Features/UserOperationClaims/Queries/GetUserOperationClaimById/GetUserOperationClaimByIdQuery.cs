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

namespace Application.Features.UserOperationClaims.Queries.GetUserOperationClaimById
{
    public class GetUserOperationClaimByIdQuery:IRequest<GetUserOperationClaimByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
         {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
        };

        public class GetUserOperationClaimByIdQueryHandler : IRequestHandler<GetUserOperationClaimByIdQuery, GetUserOperationClaimByIdDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IMapper _mapper;

            public GetUserOperationClaimByIdQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetUserOperationClaimByIdDto> Handle(GetUserOperationClaimByIdQuery request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimNotExists(request.Id);

                UserOperationClaim? getUserOperationClaim = await _userOperationClaimRepository.GetAsync(x=>x.Id == request.Id);

                GetUserOperationClaimByIdDto getUserOperationClaimByIdDto = _mapper.Map<GetUserOperationClaimByIdDto>(getUserOperationClaim);

                return getUserOperationClaimByIdDto;
            }
        }
    }
}

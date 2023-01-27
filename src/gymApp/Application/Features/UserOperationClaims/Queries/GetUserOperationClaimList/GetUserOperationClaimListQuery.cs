using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
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

namespace Application.Features.UserOperationClaims.Queries.GetUserOperationClaimList
{
    public class GetUserOperationClaimListQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            UserOperationClaimRoles.UserOperationClaimAdmin,
            UserOperationClaimRoles.UserOperationClaimRead
        };

        public class GetUserOperationClaimListQueryHandler : IRequestHandler<GetUserOperationClaimListQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetUserOperationClaimListQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<UserOperationClaimListModel> Handle(GetUserOperationClaimListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(index: request.PageRequest.Page-1, size: request.PageRequest.PageSize);

                UserOperationClaimListModel mappedUserOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);
                foreach (var userOprtClaim in mappedUserOperationClaimListModel.Items)
                {
                    userOprtClaim.Id = userOprtClaim.Id;
                    userOprtClaim.UserId = userOprtClaim.UserId;
                    userOprtClaim.OperationClaimId = userOprtClaim.OperationClaimId;
                    userOprtClaim.FirstName = (await _userRepository.GetAsync(x => x.Id == userOprtClaim.UserId)).FirstName;
                    userOprtClaim.LastName = (await _userRepository.GetAsync(x => x.Id == userOprtClaim.UserId)).LastName;
                    userOprtClaim.OperationClaimName = (await _operationClaimRepository.GetAsync(x => x.Id == userOprtClaim.OperationClaimId)).Name;
                }

                return mappedUserOperationClaimListModel;
            }
        }
    }
}

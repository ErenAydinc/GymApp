using Application.Constants;
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

namespace Application.Features.UserOperationClaims.Queries.GetUserOperationClaimListByUserId
{
    public class GetUserOperationClaimListByUserIdQuery : IRequest<UserOperationClaimListByUserIdModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public int UserId { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
            GeneralRoles.GymAdmin,
        };

        public class GetUserOperationClaimListByUserIdQueryHandler : IRequestHandler<GetUserOperationClaimListByUserIdQuery, UserOperationClaimListByUserIdModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetUserOperationClaimListByUserIdQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<UserOperationClaimListByUserIdModel> Handle(GetUserOperationClaimListByUserIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(predicate: x => x.UserId == request.UserId, index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                UserOperationClaimListByUserIdModel mappedUserOperationClaimListByUserIdModel = _mapper.Map<UserOperationClaimListByUserIdModel>(userOperationClaims);
                IList<int> newOperationClaimIds = new List<int>();
                foreach (var userOperationClaim in mappedUserOperationClaimListByUserIdModel.Items.GroupBy(x=>x.UserId).Select(x=>x.FirstOrDefault()))
                {
                    List<UserOperationClaim> userOperationClaimIds = (await _userOperationClaimRepository.GetAllAsync(x => x.UserId == userOperationClaim.UserId));
                    foreach (var userOperationClaimId in userOperationClaimIds)
                    {
                        newOperationClaimIds.Add(userOperationClaimId.OperationClaimId); 
                    }
                    userOperationClaim.OperationClaimIds = newOperationClaimIds.ToArray();

                    
                }

                foreach (var item in mappedUserOperationClaimListByUserIdModel.Items.ToList())
                {
                    if (item.OperationClaimIds == null)
                    {
                        mappedUserOperationClaimListByUserIdModel.Items.Remove(item);
                    }
                }

                return mappedUserOperationClaimListByUserIdModel;
            }
        }
    }
}

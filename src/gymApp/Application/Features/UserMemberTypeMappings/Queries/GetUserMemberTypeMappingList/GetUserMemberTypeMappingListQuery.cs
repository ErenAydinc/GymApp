using Application.Features.UserMemberTypeMappings.Constants;
using Application.Features.UserMemberTypeMappings.Models;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingList
{
    public class GetUserMemberTypeMappingListQuery : IRequest<UserMemberTypeMappingListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            UserMemberTypeMappingRoles.UserMemberTypeMappingRead,
            UserMemberTypeMappingRoles.UserMemberTypeMappingAdmin
        };

        public class GetUserMemberTypeMappingListQueryHandler : IRequestHandler<GetUserMemberTypeMappingListQuery, UserMemberTypeMappingListModel>
        {
            private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly IUserService _userService;
            private readonly UserMemberTypeMappingBusinessRules _userMemberTypeMappingBusinessRules;
            private readonly IMapper _mapper;

            public GetUserMemberTypeMappingListQueryHandler(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, UserMemberTypeMappingBusinessRules userMemberTypeMappingBusinessRules, IMapper mapper, IUserService userService, IMemberTypeRepository memberTypeRepository)
            {
                _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
                _userMemberTypeMappingBusinessRules = userMemberTypeMappingBusinessRules;
                _mapper = mapper;
                _userService = userService;
                _memberTypeRepository = memberTypeRepository;
            }

            public async Task<UserMemberTypeMappingListModel> Handle(GetUserMemberTypeMappingListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserMemberTypeMapping> userMemberTypeMapping = await _userMemberTypeMappingRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                UserMemberTypeMappingListModel mappedUserMemberTypeMappingListModel = _mapper.Map<UserMemberTypeMappingListModel>(userMemberTypeMapping);

                foreach (var userMemberType in mappedUserMemberTypeMappingListModel.Items)
                {
                    userMemberType.MemberTypeId = userMemberType.MemberTypeId;
                    userMemberType.UserId = userMemberType.UserId;
                    userMemberType.MemberTypeName = ((await _memberTypeRepository.GetAsync(x => x.Id == userMemberType.MemberTypeId)).Name);
                    userMemberType.UserName =await _userService.GetFullName(userMemberType.UserId);
                }

                return mappedUserMemberTypeMappingListModel;
            }
        }
    }
}

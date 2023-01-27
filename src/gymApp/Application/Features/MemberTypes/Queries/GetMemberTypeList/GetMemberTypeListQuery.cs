using Application.Features.MemberTypes.Constants;
using Application.Features.MemberTypes.Models;
using Application.Features.MemberTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberTypes.Queries.GetMemberTypeList
{
    public class GetMemberTypeListQuery : IRequest<MemberTypeListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } =
        {
            MemberTypeRoles.MemberTypeRead,
            MemberTypeRoles.MemberTypeAdmin
        };

        public class GetMemberTypeListQueryHandler : IRequestHandler<GetMemberTypeListQuery, MemberTypeListModel>
        {
            private readonly IMemberTypeRepository _memberTypeRepository;
            private readonly IUserRepository _userRepository;
            private readonly MemberTypeBusinessRules _memberTypeBusinessRules;
            private readonly IMapper _mapper;

            public GetMemberTypeListQueryHandler(IMemberTypeRepository memberTypeRepository, MemberTypeBusinessRules memberTypeBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _memberTypeRepository = memberTypeRepository;
                _memberTypeBusinessRules = memberTypeBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<MemberTypeListModel> Handle(GetMemberTypeListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<MemberType> memberType = await _memberTypeRepository.GetListAsync(index: request.PageRequest.Page - 1, size: request.PageRequest.PageSize);

                MemberTypeListModel mappedMemberTypeListModel = _mapper.Map<MemberTypeListModel>(memberType);

                return mappedMemberTypeListModel;
            }
        }
    }
}

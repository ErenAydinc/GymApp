using Application.Features.UserMemberTypeMappings.Constants;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingById
{
    public class GetUserMemberTypeMappingByIdQuery:IRequest<GetUserMemberTypeMappingByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            UserMemberTypeMappingRoles.UserMemberTypeMappingRead,
            UserMemberTypeMappingRoles.UserMemberTypeMappingAdmin
        };
        public class GetUserMemberTypeMappingByIdQueryHandler : IRequestHandler<GetUserMemberTypeMappingByIdQuery, GetUserMemberTypeMappingByIdDto>
        {
            private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
            private readonly UserMemberTypeMappingBusinessRules _userMemberTypeMappingBusinessRules;
            private readonly IMapper _mapper;

            public GetUserMemberTypeMappingByIdQueryHandler(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, UserMemberTypeMappingBusinessRules userMemberTypeMappingBusinessRules, IMapper mapper)
            {
                _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
                _userMemberTypeMappingBusinessRules = userMemberTypeMappingBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetUserMemberTypeMappingByIdDto> Handle(GetUserMemberTypeMappingByIdQuery request, CancellationToken cancellationToken)
            {
                await _userMemberTypeMappingBusinessRules.UserMemberTypeMappingNotExists(request.Id);

                UserMemberTypeMapping? userMemberTypeMapping = await _userMemberTypeMappingRepository.GetAsync(x=>x.Id == request.Id);

                GetUserMemberTypeMappingByIdDto getUserMemberTypeMappingByIdDto=_mapper.Map<GetUserMemberTypeMappingByIdDto>(userMemberTypeMapping);

                return getUserMemberTypeMappingByIdDto;
            }
        }
    }
}

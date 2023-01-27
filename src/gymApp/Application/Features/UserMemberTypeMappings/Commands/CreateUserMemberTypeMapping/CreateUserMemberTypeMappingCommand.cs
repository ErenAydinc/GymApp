using Application.Features.UserMemberTypeMappings.Constants;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UserMemberTypeMappings.Commands.CreateUserMemberTypeMapping
{
    public class CreateUserMemberTypeMappingCommand:IRequest<CreateUserMemberTypeMappingDto>,ISecuredRequest
    {
        public int UserId { get; set; }
        public int MemberTypeId { get; set; }

        public string[] Roles { get; } =
        {
            UserMemberTypeMappingRoles.UserMemberTypeMappingCreate,
            UserMemberTypeMappingRoles.UserMemberTypeMappingAdmin
        };

        public class CreateUserMemberTypeMappingCommandHandler : IRequestHandler<CreateUserMemberTypeMappingCommand, CreateUserMemberTypeMappingDto>
        {
            private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
            private readonly UserMemberTypeMappingBusinessRules _userMemberTypeMappingBusinessRules;
            private readonly IMapper _mapper;
            public CreateUserMemberTypeMappingCommandHandler(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, UserMemberTypeMappingBusinessRules userMemberTypeMappingBusinessRules, IMapper mapper)
            {
                _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
                _userMemberTypeMappingBusinessRules = userMemberTypeMappingBusinessRules;
                _mapper = mapper;
            }
            public async Task<CreateUserMemberTypeMappingDto> Handle(CreateUserMemberTypeMappingCommand request, CancellationToken cancellationToken)
            {
                await _userMemberTypeMappingBusinessRules.UserIdNotExists(request.UserId);
                await _userMemberTypeMappingBusinessRules.MemberTypeNotExists(request.MemberTypeId);

                UserMemberTypeMapping? userMemberTypeMapping = _mapper.Map<UserMemberTypeMapping>(request);

                UserMemberTypeMapping mappedUserMemberTypeMapping = await _userMemberTypeMappingRepository.AddAsync(userMemberTypeMapping);

                CreateUserMemberTypeMappingDto createUserMemberTypeMappingDto = _mapper.Map<CreateUserMemberTypeMappingDto>(mappedUserMemberTypeMapping);

                return createUserMemberTypeMappingDto;
            }
        }
    }
}

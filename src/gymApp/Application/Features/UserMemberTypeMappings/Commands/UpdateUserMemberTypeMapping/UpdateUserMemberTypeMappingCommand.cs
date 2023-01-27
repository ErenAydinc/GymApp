using Application.Features.UserMemberTypeMappings.Constants;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UserMemberTypeMappings.Commands.UpdateUserMemberTypeMapping
{
    public class UpdateUserMemberTypeMappingCommand:IRequest<UpdateUserMemberTypeMappingDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MemberTypeId { get; set; }

        public string[] Roles { get; } =
        {
            UserMemberTypeMappingRoles.UserMemberTypeMappingUpdate,
            UserMemberTypeMappingRoles.UserMemberTypeMappingAdmin
        };

        public class UpdateUserMemberTypeMappingCommandHandler : IRequestHandler<UpdateUserMemberTypeMappingCommand, UpdateUserMemberTypeMappingDto>
        {
            private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
            private readonly UserMemberTypeMappingBusinessRules _userMemberTypeMappingBusinessRules;
            private readonly IMapper _mapper;
            public UpdateUserMemberTypeMappingCommandHandler(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, UserMemberTypeMappingBusinessRules userMemberTypeMappingBusinessRules, IMapper mapper)
            {
                _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
                _userMemberTypeMappingBusinessRules = userMemberTypeMappingBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdateUserMemberTypeMappingDto> Handle(UpdateUserMemberTypeMappingCommand request, CancellationToken cancellationToken)
            {
                await _userMemberTypeMappingBusinessRules.UserMemberTypeMappingNotExists(request.Id);

                await _userMemberTypeMappingBusinessRules.UserIdNotExists(request.UserId);

                await _userMemberTypeMappingBusinessRules.MemberTypeNotExists(request.MemberTypeId);

                UserMemberTypeMapping? userMemberTypeMapping = _mapper.Map<UserMemberTypeMapping>(request);

                UserMemberTypeMapping mappedUserMemberTypeMapping = await _userMemberTypeMappingRepository.UpdateAsync(userMemberTypeMapping);

                UpdateUserMemberTypeMappingDto updateUserMemberTypeMappingDto = _mapper.Map<UpdateUserMemberTypeMappingDto>(mappedUserMemberTypeMapping);

                return updateUserMemberTypeMappingDto;
            }
        }
    }
}

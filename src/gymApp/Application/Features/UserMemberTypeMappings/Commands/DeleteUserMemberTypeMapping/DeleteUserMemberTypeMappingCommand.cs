using Application.Features.UserMemberTypeMappings.Constants;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.UserMemberTypeMappings.Commands.DeleteUserMemberTypeMapping
{
    public class DeleteUserMemberTypeMappingCommand:IRequest<DeleteUserMemberTypeMappingDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            UserMemberTypeMappingRoles.UserMemberTypeMappingDelete,
            UserMemberTypeMappingRoles.UserMemberTypeMappingAdmin
        };

        public class DeleteUserMemberTypeMappingCommandHandler : IRequestHandler<DeleteUserMemberTypeMappingCommand, DeleteUserMemberTypeMappingDto>
        {
            private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
            private readonly UserMemberTypeMappingBusinessRules _userMemberTypeMappingBusinessRules;
            private readonly IMapper _mapper;

            public DeleteUserMemberTypeMappingCommandHandler(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, UserMemberTypeMappingBusinessRules userMemberTypeMappingBusinessRules, IMapper mapper)
            {
                _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
                _userMemberTypeMappingBusinessRules = userMemberTypeMappingBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteUserMemberTypeMappingDto> Handle(DeleteUserMemberTypeMappingCommand request, CancellationToken cancellationToken)
            {
                await _userMemberTypeMappingBusinessRules.UserMemberTypeMappingNotExists(request.Id);

                UserMemberTypeMapping? userMemberTypeMapping = _mapper.Map<UserMemberTypeMapping>(request);

                UserMemberTypeMapping? mappedUserMemberTypeMapping = await _userMemberTypeMappingRepository.DeleteAsync(userMemberTypeMapping);

                DeleteUserMemberTypeMappingDto deleteUserMemberTypeMappingDto = _mapper.Map<DeleteUserMemberTypeMappingDto>(mappedUserMemberTypeMapping);

                return deleteUserMemberTypeMappingDto;
            }
        }
    }
}

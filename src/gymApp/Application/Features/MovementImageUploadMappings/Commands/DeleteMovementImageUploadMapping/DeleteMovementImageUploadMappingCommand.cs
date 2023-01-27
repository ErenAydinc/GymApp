using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Commands.DeleteMovementImageUploadMapping
{
    public class DeleteMovementImageUploadMappingCommand:IRequest<DeleteMovementImageUploadMappingDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingDelete,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };

        public class DeleteMovementImageUploadMappingCommandHandler : IRequestHandler<DeleteMovementImageUploadMappingCommand, DeleteMovementImageUploadMappingDto>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;

            public DeleteMovementImageUploadMappingCommandHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeleteMovementImageUploadMappingDto> Handle(DeleteMovementImageUploadMappingCommand request, CancellationToken cancellationToken)
            {
                await _movementImageUploadMappingBusinessRules.MovementImageUploadMappingNotExists(request.Id);

                MovementImageUploadMapping? movementImageUploadMapping = _mapper.Map<MovementImageUploadMapping>(request);

                MovementImageUploadMapping? mappedMovementImageUploadMapping = await _movementImageUploadMappingRepository.DeleteAsync(movementImageUploadMapping);

                DeleteMovementImageUploadMappingDto deleteMovementImageUploadMappingDto = _mapper.Map<DeleteMovementImageUploadMappingDto>(mappedMovementImageUploadMapping);

                return deleteMovementImageUploadMappingDto;
            }
        }
    }
}

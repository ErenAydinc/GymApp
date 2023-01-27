using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Commands.UpdateMovementImageUploadMapping
{
    public class UpdateMovementImageUploadMappingCommand:IRequest<UpdateMovementImageUploadMappingDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int MovementId { get; set; }
        public int ImageUploadId { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingUpdate,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };

        public class UpdateMovementImageUploadMappingCommandHandler : IRequestHandler<UpdateMovementImageUploadMappingCommand, UpdateMovementImageUploadMappingDto>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;
            public UpdateMovementImageUploadMappingCommandHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
            }
            public async Task<UpdateMovementImageUploadMappingDto> Handle(UpdateMovementImageUploadMappingCommand request, CancellationToken cancellationToken)
            {
                await _movementImageUploadMappingBusinessRules.MovementImageUploadMappingNotExists(request.Id);

                MovementImageUploadMapping? movementImageUploadMapping = _mapper.Map<MovementImageUploadMapping>(request);

                MovementImageUploadMapping mappedMovementImageUploadMapping = await _movementImageUploadMappingRepository.UpdateAsync(movementImageUploadMapping);

                UpdateMovementImageUploadMappingDto updateMovementImageUploadMappingDto = _mapper.Map<UpdateMovementImageUploadMappingDto>(mappedMovementImageUploadMapping);

                return updateMovementImageUploadMappingDto;
            }
        }
    }
}

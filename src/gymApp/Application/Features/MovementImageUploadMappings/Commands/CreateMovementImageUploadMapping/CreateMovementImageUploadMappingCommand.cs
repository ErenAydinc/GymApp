using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Commands.CreateMovementImageUploadMapping
{
    public class CreateMovementImageUploadMappingCommand:IRequest<CreateMovementImageUploadMappingDto>,ISecuredRequest
    {
        public int MovementId { get; set; }
        public int ImageUploadId { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingCreate,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };

        public class CreateMovementImageUploadMappingCommandHandler : IRequestHandler<CreateMovementImageUploadMappingCommand, CreateMovementImageUploadMappingDto>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;
            public CreateMovementImageUploadMappingCommandHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
            }
            public async Task<CreateMovementImageUploadMappingDto> Handle(CreateMovementImageUploadMappingCommand request, CancellationToken cancellationToken)
            {

                MovementImageUploadMapping? movementImageUploadMapping = _mapper.Map<MovementImageUploadMapping>(request);

                MovementImageUploadMapping mappedMovementImageUploadMapping = await _movementImageUploadMappingRepository.AddAsync(movementImageUploadMapping);

                CreateMovementImageUploadMappingDto createMovementImageUploadMappingDto = _mapper.Map<CreateMovementImageUploadMappingDto>(mappedMovementImageUploadMapping);

                return createMovementImageUploadMappingDto;
            }
        }
    }
}

using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingById
{
    public class GetMovementImageUploadMappingByIdQuery:IRequest<GetMovementImageUploadMappingByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingRead,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };
        public class GetMovementImageUploadMappingByIdQueryHandler : IRequestHandler<GetMovementImageUploadMappingByIdQuery, GetMovementImageUploadMappingByIdDto>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;

            public GetMovementImageUploadMappingByIdQueryHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetMovementImageUploadMappingByIdDto> Handle(GetMovementImageUploadMappingByIdQuery request, CancellationToken cancellationToken)
            {
                await _movementImageUploadMappingBusinessRules.MovementImageUploadMappingNotExists(request.Id);

                MovementImageUploadMapping? movementImageUploadMapping = await _movementImageUploadMappingRepository.GetAsync(x=>x.Id == request.Id);

                GetMovementImageUploadMappingByIdDto getMovementImageUploadMappingByIdDto=_mapper.Map<GetMovementImageUploadMappingByIdDto>(movementImageUploadMapping);

                return getMovementImageUploadMappingByIdDto;
            }
        }
    }
}

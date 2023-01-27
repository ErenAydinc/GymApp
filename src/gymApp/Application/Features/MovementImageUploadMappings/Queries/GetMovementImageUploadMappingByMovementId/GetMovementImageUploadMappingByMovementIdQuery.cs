using Application.Features.MovementImageUploadMappings.Constants;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.MappingEntities;
using MediatR;

namespace Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingByMovementId
{
    public class GetMovementImageUploadMappingByMovementIdQuery:IRequest<GetMovementImageUploadMappingByMovementIdDto>,ISecuredRequest
    {
        public int MovementId { get; set; }

        public string[] Roles { get; } =
        {
            MovementImageUploadMappingRoles.MovementImageUploadMappingRead,
            MovementImageUploadMappingRoles.MovementImageUploadMappingAdmin
        };
        public class GetMovementImageUploadMappingByMovementIdQueryHandler : IRequestHandler<GetMovementImageUploadMappingByMovementIdQuery, GetMovementImageUploadMappingByMovementIdDto>
        {
            private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
            private readonly MovementImageUploadMappingBusinessRules _movementImageUploadMappingBusinessRules;
            private readonly IMapper _mapper;

            public GetMovementImageUploadMappingByMovementIdQueryHandler(IMovementImageUploadMappingRepository movementImageUploadMappingRepository, MovementImageUploadMappingBusinessRules movementImageUploadMappingBusinessRules, IMapper mapper)
            {
                _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
                _movementImageUploadMappingBusinessRules = movementImageUploadMappingBusinessRules;
                _mapper = mapper;
            }

            public async Task<GetMovementImageUploadMappingByMovementIdDto> Handle(GetMovementImageUploadMappingByMovementIdQuery request, CancellationToken cancellationToken)
            {
                //await _movementImageUploadMappingBusinessRules.MovementImageUploadMappingNotExists(request.Id);

                MovementImageUploadMapping? movementImageUploadMapping = await _movementImageUploadMappingRepository.GetAsync(x=>x.MovementId == request.MovementId);

                GetMovementImageUploadMappingByMovementIdDto getMovementImageUploadMappingByMovementIdDto=_mapper.Map<GetMovementImageUploadMappingByMovementIdDto>(movementImageUploadMapping);

                return getMovementImageUploadMappingByMovementIdDto;
            }
        }
    }
}

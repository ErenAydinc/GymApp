using Application.Features.Movements.Constants;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Commands.CreateMovement
{
    public class CreateMovementCommand : IRequest<CreateMovementDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles { get; } =
        {
            MovementRoles.MovementAdmin,
            MovementRoles.MovementCreate
        };

        public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, CreateMovementDto>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public CreateMovementCommandHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreateMovementDto> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
            {
                Movement? mappedMovement = _mapper.Map<Movement>(request);

                Movement createMovement = await _movementRepository.AddAsync(mappedMovement);

                CreateMovementDto createMovementDto = _mapper.Map<CreateMovementDto>(createMovement);

                return createMovementDto;
            }
        }
    }
}

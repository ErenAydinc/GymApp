using Application.Constants;
using Application.Features.Movements.Constants;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Rules;
using Application.Helpers;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.MappingEntities;
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
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string[] Roles { get; } =
        {
            GeneralRoles.SystemAdmin,
        };

        public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, CreateMovementDto>
        {
            private readonly IMovementRepository _movementRepository;
            private readonly ICustomerToMovementMappingRepository _customerToMovementMappingRepository;
            private readonly IHelperService _helperService;
            private readonly MovementBusinessRules _movementBusinessRules;
            private readonly IMapper _mapper;

            public CreateMovementCommandHandler(IMovementRepository movementRepository, MovementBusinessRules movementBusinessRules, IMapper mapper, ICustomerToMovementMappingRepository customerToMovementMappingRepository, IHelperService helperService)
            {
                _movementRepository = movementRepository;
                _movementBusinessRules = movementBusinessRules;
                _mapper = mapper;
                _customerToMovementMappingRepository = customerToMovementMappingRepository;
                _helperService = helperService;
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

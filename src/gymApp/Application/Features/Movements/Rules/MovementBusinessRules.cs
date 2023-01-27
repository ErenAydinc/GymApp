using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movements.Rules
{
    public class MovementBusinessRules
    {
        private readonly IMovementRepository _movementRepository;

        public MovementBusinessRules(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task MovementAlreadyExists(int id)
        {
            Movement? movement = await _movementRepository.GetAsync(x => x.Id == id);

            if (movement != null) throw new BusinessException("Movement already exists");
        }

        public async Task MovementNotAlreadyExists(int id)
        {
            Movement? movement = await _movementRepository.GetAsync(x => x.Id == id);

            if (movement == null) throw new BusinessException("Movement not already exists");
        }
    }
}

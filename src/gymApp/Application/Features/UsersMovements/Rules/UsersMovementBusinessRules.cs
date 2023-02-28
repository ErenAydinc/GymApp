using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using Domain.MappingEntities;

namespace Application.Features.UsersMovements.Rules
{
    public class UsersMovementBusinessRules
    {
        private readonly IUsersMovementRepository _usersMovementRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMovementRepository _movementRepository;
        public UsersMovementBusinessRules(IUsersMovementRepository usersMovementRepository, IUserRepository userRepository, IMovementRepository movementRepository)
        {
            _usersMovementRepository = usersMovementRepository;
            _userRepository = userRepository;
            _movementRepository = movementRepository;
        }

        public async Task UsersMovementNotExists(int id)
        {
            UsersMovement? usersMovement = await _usersMovementRepository.GetAsync(x => x.Id == id);

            if (usersMovement == null) throw new BusinessException("Users Movement not exists");
        }

        public async Task UserIdNotExists(int userId)
        {
            User? user= await _userRepository.GetAsync(x => x.Id == userId);

            if (user == null) throw new BusinessException("User not exists");
        }

        public async Task MovementNotExists(int MovementId)
        {
            Movement? Movement = await _movementRepository.GetAsync(x => x.Id == MovementId);

            if (Movement == null) throw new BusinessException("Movement not exists");
        }
    }
}

using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.MappingEntities;

namespace Application.Features.MovementImageUploadMappings.Rules
{
    public class MovementImageUploadMappingBusinessRules
    {
        private readonly IMovementImageUploadMappingRepository _movementImageUploadMappingRepository;
        public MovementImageUploadMappingBusinessRules(IMovementImageUploadMappingRepository movementImageUploadMappingRepository)
        {
            _movementImageUploadMappingRepository = movementImageUploadMappingRepository;
        }

        public async Task MovementImageUploadMappingNotExists(int movementImageUploadMappingId)
        {
            MovementImageUploadMapping? movementImageUploadMapping = await _movementImageUploadMappingRepository.GetAsync(x => x.Id == movementImageUploadMappingId);

            if (movementImageUploadMapping == null) throw new BusinessException("MovementImageUploadMapping not exists");
        }

        //public async Task MovementImageUploadMappingNameExists(string name)
        //{
        //    MovementImageUploadMapping? movementImageUploadMapping= await _movementImageUploadMappingRepository.GetAsync(x => x.Name == name);

        //    if (movementImageUploadMapping != null) throw new BusinessException("Member type name already exists");
        //}
    }
}

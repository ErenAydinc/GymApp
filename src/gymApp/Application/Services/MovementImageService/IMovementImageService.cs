using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.MovementImageService
{
    public interface IMovementImageService
    {
        Task<MovementImage> AddAsync(MovementImage movementImage, IFormFile file);
        Task DeleteAsync(MovementImage movementImage);
        Task UpdateAsync(MovementImage movementImage, IFormFile file);
        Task<IPaginate<MovementImage>> GetAll(PageRequest pageRequest);
        Task<MovementImage> GetById(int id);
        Task<List<MovementImage>> GetByMovementId(int movementId);
    }
}

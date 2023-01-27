using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ImageService
{
    public interface IImageService
    {
        Task<ImageUpload> AddAsync(ImageUpload imageUpload, List<IFormFile> files);
        Task DeleteAsync(ImageUpload imageUpload);
        Task UpdateAsync(ImageUpload imageUpload, IFormFile file);
        Task<IPaginate<ImageUpload>> GetAll(PageRequest pageRequest);
        Task<ImageUpload> GetById(int id);
    }
}

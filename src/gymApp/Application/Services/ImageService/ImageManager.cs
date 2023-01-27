using Application.Services.Repositories;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.ImageService
{
    internal class ImageManager : IImageService
    {
        private readonly IImageUploadRepository _imageUploadRepository;

        public ImageManager(IImageUploadRepository imageUploadRepository)
        {
            _imageUploadRepository = imageUploadRepository;
        }

        public async Task<ImageUpload> AddAsync(ImageUpload imageUpload, List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    imageUpload.ImagePath = FileHelper.Add(file);
                    imageUpload.DateTime = DateTime.Now;
                    imageUpload.Id = imageUpload.Id;
                    await _imageUploadRepository.AddAsync(imageUpload);
                }
                return imageUpload;
            }
            throw new BusinessException("NotAdded");
        }

        public async Task DeleteAsync(ImageUpload imageUpload)
        {
            var deleteImageUpload = await _imageUploadRepository.GetAsync(x => x.Id == imageUpload.Id);
            FileHelper.Delete(deleteImageUpload.ImagePath);
            await _imageUploadRepository.DeleteAsync(deleteImageUpload);
            throw new Exception("Deleted");
        }

        public async Task<IPaginate<ImageUpload>> GetAll(PageRequest pageRequest)
        {
            IPaginate<ImageUpload> imageUpload = await _imageUploadRepository.GetListAsync(index: pageRequest.Page - 1, size: pageRequest.PageSize);
            return imageUpload;
        }

        public async Task UpdateAsync(ImageUpload imageUpload, IFormFile file)
        {

            ImageUpload? getImageUpload = await _imageUploadRepository.GetAsync(x => x.Id == imageUpload.Id);
            imageUpload.ImagePath = FileHelper.Update(file,getImageUpload.ImagePath);
            imageUpload.DateTime = DateTime.Now;
            imageUpload.Id = getImageUpload.Id;
            await _imageUploadRepository.AddAsync(imageUpload);
            throw new Exception("Updated");
        }

        public async Task<ImageUpload> GetById(int id)
        {
            ImageUpload? imageUpload = await _imageUploadRepository.GetAsync(x=>x.Id==id);
            return imageUpload;
        }
    }
}

using Application.Services.Repositories;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Helpers;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.MovementImageService
{
    internal class MovementImageManager : IMovementImageService
    {
        private readonly IMovementImageRepository _movementImageRepository;

        public MovementImageManager(IMovementImageRepository movementImageRepository)
        {
            _movementImageRepository = movementImageRepository;
        }

        public async Task<MovementImage> AddAsync(MovementImage movementImage, IFormFile file)
        {

            movementImage.ImagePath = FileHelper.Add(file);
            movementImage.DateTime = DateTime.Now;
            await _movementImageRepository.AddAsync(movementImage);
            return movementImage;

            //if (files.Count > 0)
            //{
            //    foreach (var file in files)
            //    {
            //        movementImage.ImagePath = FileHelper.Add(file);
            //        movementImage.DateTime = DateTime.Now;
            //        movementImage.Id = movementImage.Id;
            //        await _movementImageRepository.AddAsync(movementImage);
            //    }
            //    return movementImage;
            //}
            throw new Exception("Not Added");
        }

        public async Task DeleteAsync(MovementImage movementImage)
        {
            var deleteMovementImage = await _movementImageRepository.GetAsync(x => x.Id == movementImage.Id);
            FileHelper.Delete(deleteMovementImage.ImagePath);
            await _movementImageRepository.DeleteAsync(deleteMovementImage);
            throw new Exception("Deleted");
        }

        public async Task<IPaginate<MovementImage>> GetAll(PageRequest pageRequest)
        {
            IPaginate<MovementImage> movementImage = await _movementImageRepository.GetListAsync(index: pageRequest.Page - 1, size: pageRequest.PageSize);
            return movementImage;
        }

        public async Task UpdateAsync(MovementImage movementImage, IFormFile file)
        {

            MovementImage? getMovementImage = await _movementImageRepository.GetAsync(x => x.Id == movementImage.Id);
            movementImage.ImagePath = FileHelper.Update(file,getMovementImage.ImagePath);
            movementImage.DateTime = DateTime.Now;
            movementImage.Id = getMovementImage.Id;
            await _movementImageRepository.AddAsync(movementImage);
            throw new Exception("Updated");
        }

        public async Task<MovementImage> GetById(int id)
        {
            MovementImage? movementImage = await _movementImageRepository.GetAsync(x=>x.Id==id);
            return movementImage;
        }

        public async Task<List<MovementImage>> GetByMovementId(int movementId)
        {
            List<MovementImage?> movementImage = await _movementImageRepository.GetAllAsync(x=>x.MovementId==movementId);
            return movementImage;
        }
    }
}

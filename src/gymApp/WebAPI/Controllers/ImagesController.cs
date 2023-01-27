using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Domain.Entities;
using Application.Services.ImageService;
using Core.Application.Requests;
using Core.Persistence.Paging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ImageUpload imageUpload, [FromForm(Name =("Image"))]List<IFormFile> files)
        {
            if (files == null)
            {
                return BadRequest();
            }
            await _imageService.AddAsync(imageUpload, files);

            return Ok(imageUpload);
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm] ImageUpload imageUpload)
        {
            await _imageService.DeleteAsync(imageUpload);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromForm] ImageUpload imageUpload, [FromForm(Name = ("Image"))] IFormFile file)
        {
            await _imageService.UpdateAsync(imageUpload,file);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int id)
        {
            await _imageService.GetById(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            IPaginate<ImageUpload> imageUpload = await _imageService.GetAll(pageRequest);

            return Ok(imageUpload);
        }
    }
}

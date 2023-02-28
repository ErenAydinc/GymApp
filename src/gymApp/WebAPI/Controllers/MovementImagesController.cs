using Application.Services.MovementImageService;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovementImagesController : BaseController
    {
        private readonly IMovementImageService _movementImageService;

        public MovementImagesController(IMovementImageService movementImageService)
        {
            _movementImageService = movementImageService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] MovementImage movementImage, [FromForm(Name = ("MovementImage"))] IFormFile[] files)
        {
            if (files == null)
            {
                return BadRequest();
            }
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    MovementImage movementimage = new()
                    {
                        DateTime = movementImage.DateTime,
                        Id = 0,
                        ImagePath = movementImage.ImagePath,
                        MovementId = movementImage.MovementId
                    };
                    await _movementImageService.AddAsync(movementimage, file);
                }
                return Ok("Success");
            }
            return BadRequest();

        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm] MovementImage movementImage)
        {
            await _movementImageService.DeleteAsync(movementImage);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromForm] MovementImage movementImage, [FromForm(Name = ("MovementImage"))] IFormFile file)
        {
            await _movementImageService.UpdateAsync(movementImage, file);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int id)
        {
            await _movementImageService.GetById(id);

            return Ok();
        }

        [HttpGet("{MovementId}")]
        public async Task<ActionResult> GetByMovementId(int movementId)
        {
            IList<MovementImage> movementImages = await _movementImageService.GetByMovementId(movementId);

            return Ok(movementImages);
        }

        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            IPaginate<MovementImage> movementImage = await _movementImageService.GetAll(pageRequest);

            return Ok(movementImage);
        }
    }
}

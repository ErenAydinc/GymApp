using Application.Features.MovementImageUploadMappings.Commands.CreateMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Commands.DeleteMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Commands.UpdateMovementImageUploadMapping;
using Application.Features.MovementImageUploadMappings.Dtos;
using Application.Features.MovementImageUploadMappings.Models;
using Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingById;
using Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingByMovementId;
using Application.Features.MovementImageUploadMappings.Queries.GetMovementImageUploadMappingList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovementImageUploadMappingsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetMovementImageUploadMappingListQuery getMovementImageUploadMappingListQuery = new() { PageRequest = pageRequest };
            MovementImageUploadMappingListModel userListModel = await Mediator.Send(getMovementImageUploadMappingListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMovementImageUploadMappingByIdQuery getMovementImageUploadMappingByIdQuery)
        {
            GetMovementImageUploadMappingByIdDto getMovementImageUploadMappingByIdDto = await Mediator.Send(getMovementImageUploadMappingByIdQuery);
            return Ok(getMovementImageUploadMappingByIdDto);
        }

        [HttpGet("{MovementId}")]
        public async Task<IActionResult> GetByMovementId([FromRoute] GetMovementImageUploadMappingByMovementIdQuery getMovementImageUploadMappingByMovementIdQuery)
        {
            GetMovementImageUploadMappingByMovementIdDto getMovementImageUploadMappingByMovementIdDto = await Mediator.Send(getMovementImageUploadMappingByMovementIdQuery);
            return Ok(getMovementImageUploadMappingByMovementIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovementImageUploadMappingCommand createMovementImageUploadMappingCommand)
        {
            CreateMovementImageUploadMappingDto createMovementImageUploadMappingDto = await Mediator.Send(createMovementImageUploadMappingCommand);
            return Created("",createMovementImageUploadMappingDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovementImageUploadMappingCommand updateMovementImageUploadMappingCommand)
        {
            UpdateMovementImageUploadMappingDto updateMovementImageUploadMappingDto = await Mediator.Send(updateMovementImageUploadMappingCommand);
            return Ok(updateMovementImageUploadMappingDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMovementImageUploadMappingCommand deleteMovementImageUploadMappingCommand)
        {
            DeleteMovementImageUploadMappingDto deleteMovementImageUploadMappingDto = await Mediator.Send(deleteMovementImageUploadMappingCommand);
            return Ok(deleteMovementImageUploadMappingDto);
        }
    }
}

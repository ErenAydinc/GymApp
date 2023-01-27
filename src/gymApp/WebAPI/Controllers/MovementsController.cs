using Application.Features.Movements.Commands.CreateMovement;
using Application.Features.Movements.Commands.DeleteMovement;
using Application.Features.Movements.Commands.UpdateMovement;
using Application.Features.Movements.Dtos;
using Application.Features.Movements.Models;
using Application.Features.Movements.Queries.GetMovementById;
using Application.Features.Movements.Queries.GetMovementList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovementsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetMovementListQuery getMovementListQuery = new() { PageRequest = pageRequest };
            MovementListModel movementListModel = await Mediator.Send(getMovementListQuery);
            return Ok(movementListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMovementByIdQuery getMovementByIdQuery)
        {
            GetMovementByIdDto getMovementByIdDto = await Mediator.Send(getMovementByIdQuery);
            return Ok(getMovementByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovementCommand createMovementCommand)
        {
            CreateMovementDto createMovementDto = await Mediator.Send(createMovementCommand);
            return Created("",createMovementDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovementCommand updateMovementCommand)
        {
            UpdateMovementDto updateMovementDto = await Mediator.Send(updateMovementCommand);
            return Ok(updateMovementDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMovementCommand deleteMovementCommand)
        {
            DeleteMovementDto deleteMovementDto = await Mediator.Send(deleteMovementCommand);
            return Ok(deleteMovementDto);
        }
    }
}

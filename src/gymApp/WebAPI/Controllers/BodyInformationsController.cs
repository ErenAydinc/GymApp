using Application.Features.BodyInformations.Commands.CreateBodyInformation;
using Application.Features.BodyInformations.Commands.DeleteBodyInformation;
using Application.Features.BodyInformations.Commands.UpdateBodyInformation;
using Application.Features.BodyInformations.Dtos;
using Application.Features.BodyInformations.Models;
using Application.Features.BodyInformations.Queries.GetBodyInformationById;
using Application.Features.BodyInformations.Queries.GetBodyInformationList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BodyInformationsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetBodyInformationListQuery getBodyInformationListQuery = new() { PageRequest = pageRequest };
            BodyInformationListModel movementListModel = await Mediator.Send(getBodyInformationListQuery);
            return Ok(movementListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBodyInformationByIdQuery getBodyInformationByIdQuery)
        {
            GetBodyInformationByIdDto getBodyInformationByIdDto = await Mediator.Send(getBodyInformationByIdQuery);
            return Ok(getBodyInformationByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBodyInformationCommand createBodyInformationCommand)
        {
            CreateBodyInformationDto createBodyInformationDto = await Mediator.Send(createBodyInformationCommand);
            return Created("",createBodyInformationDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBodyInformationCommand updateBodyInformationCommand)
        {
            UpdateBodyInformationDto updateBodyInformationDto = await Mediator.Send(updateBodyInformationCommand);
            return Ok(updateBodyInformationDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBodyInformationCommand deleteBodyInformationCommand)
        {
            DeleteBodyInformationDto deleteBodyInformationDto = await Mediator.Send(deleteBodyInformationCommand);
            return Ok(deleteBodyInformationDto);
        }
    }
}

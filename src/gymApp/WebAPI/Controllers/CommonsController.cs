using Application.Features.Commons.Commands.CommonCreateCommonBodyInformation;
using Application.Features.Commons.Commands.CommonUpdateCommonBodyInformation;
using Application.Features.Commons.Dtos;
using Application.Features.Commons.Models;
using Application.Features.Commons.Queries.GetCommonMovementList;
using Application.Features.Commons.Queries.GetCommonPersonalTrainerList;
using Application.Features.Commons.Queries.GetCommonPersonalTrainerStudentList;
using Application.Features.Commons.Queries.GetCommonStudentById;
using Application.Features.Commons.Queries.GetCommonStudentList;
using Application.Features.Commons.Queries.GetCommonStudentMovementListByStudentIdAndSelectedDay;
using Application.Features.Commons.Queries.GetCommonUserMovementList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetListStudent([FromQuery] PageRequest pageRequest)
        {
            GetCommonStudentListQuery getCommonStudentListQuery = new() { PageRequest = pageRequest};
            CommonStudentListModel commonStudentListModel= await Mediator.Send(getCommonStudentListQuery);
            return Ok(commonStudentListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPersonalTrainer([FromQuery] PageRequest pageRequest)
        {
            GetCommonPersonalTrainerListQuery getCommonPersonalTrainerListQuery = new() { PageRequest = pageRequest };
            CommonPersonalTrainerListModel commonPersonalTrainerListModel = await Mediator.Send(getCommonPersonalTrainerListQuery);
            return Ok(commonPersonalTrainerListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListMovement([FromQuery] PageRequest pageRequest,[FromQuery] string? searchMovementName)
        {
            GetCommonMovementListQuery getCommonMovementListQuery = new() { PageRequest = pageRequest,SearchMovementName=searchMovementName };
            CommonMovementListModel commonMovementListModel = await Mediator.Send(getCommonMovementListQuery);
            return Ok(commonMovementListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListUserMovement([FromQuery] PageRequest pageRequest, [FromQuery] int selectedDay)
        {
            GetCommonUserMovementListQuery getCommonUserMovementListQuery = new() { PageRequest = pageRequest,SelectedDay=selectedDay };
            CommonUserMovementListModel commonUserMovementListModel = await Mediator.Send(getCommonUserMovementListQuery);
            return Ok(commonUserMovementListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListStudentMovementByStudentIdAndSelectedDay([FromQuery] PageRequest pageRequest, [FromQuery] int studentId, [FromQuery] int selectedDay)
        {
            GetCommonStudentMovementListByStudentIdAndSelectedDayQuery getCommonStudentMovementListByStudentIdAndSelectedDayQuery= new() { PageRequest = pageRequest,StudentId= studentId, SelectedDay = selectedDay };
            CommonStudentMovementListByStudentIdAndSelectedDayModel commonStudentMovementListByStudentIdAndSelectedDayModel= await Mediator.Send(getCommonStudentMovementListByStudentIdAndSelectedDayQuery);
            return Ok(commonStudentMovementListByStudentIdAndSelectedDayModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListPersonalTrainerStudent()
        {
            GetCommonPersonalTrainerStudentListQuery getCommonPersonalTrainerStudentListQuery= new();
            CommonPersonalTrainerStudentListModel commonPersonalTrainerStudentListModel= await Mediator.Send(getCommonPersonalTrainerStudentListQuery);
            return Ok(commonPersonalTrainerStudentListModel);
        }

        [HttpGet ("{Id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] GetCommonStudentByIdQuery getCommonStudentByIdQuery)
        {
            CommonStudentByIdDto commonStudentByIdDto = await Mediator.Send(getCommonStudentByIdQuery);
            return Ok(commonStudentByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommonBodyInformationCommand createCommonBodyInformationCommand)
        {
            CommonCreateBodyInformationDto commonCreateBodyInformationDto = await Mediator.Send(createCommonBodyInformationCommand);
            return Created("", commonCreateBodyInformationDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommonBodyInformationCommand updateCommonBodyInformationCommand)
        {
            CommonUpdateBodyInformationDto commonUpdateBodyInformationDto = await Mediator.Send(updateCommonBodyInformationCommand);
            return Ok(commonUpdateBodyInformationDto);
        }
    }
}

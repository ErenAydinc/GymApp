using Application.Features.Commons.Models;
using Application.Features.Commons.Queries.GetCommonMovementList;
using Application.Features.Commons.Queries.GetCommonPersonalTrainerList;
using Application.Features.Commons.Queries.GetCommonStudentList;
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
        public async Task<IActionResult> GetListMovement([FromQuery] PageRequest pageRequest)
        {
            GetCommonMovementListQuery getCommonMovementListQuery = new() { PageRequest = pageRequest };
            CommonMovementListModel commonMovementListModel = await Mediator.Send(getCommonMovementListQuery);
            return Ok(commonMovementListModel);
        }
    }
}

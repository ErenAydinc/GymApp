using Application.Features.UsersMovements.Commands.CreateUsersMovement;
using Application.Features.UsersMovements.Commands.DeleteUsersMovement;
using Application.Features.UsersMovements.Commands.UpdateUsersMovement;
using Application.Features.UsersMovements.Dtos;
using Application.Features.UsersMovements.Models;
using Application.Features.UsersMovements.Queries.GetUsersMovementById;
using Application.Features.UsersMovements.Queries.GetUsersMovementList;
using Application.Features.UsersMovements.Queries.GetUsersMovementsByUserId;
using Application.Features.UsersMovements.Queries.GetUsersMovementsByUserIdAndSelectedDay;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersMovementsController : BaseController
    {

        /// <summary>
        /// adminin bağlı olduğu customerın öğrencilerinin hareketlerini gösterir
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetUsersMovementListQuery getUsersMovementListQuery = new() { PageRequest = pageRequest };
            UsersMovementListModel userListModel = await Mediator.Send(getUsersMovementListQuery);
            return Ok(userListModel);
        }

        /// <summary>
        /// Personal Trainerin öğrencisinin hareketlerini gösterir
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetListByUserId([FromQuery] PageRequest pageRequest, [FromQuery] int userId)
        {
            GetUsersMovementsByUserIdQuery getUsersMovementsByUserIdQuery = new() { UserId=userId,PageRequest = pageRequest};
            UsersMovementsListByUserIdModel usersMovementsListByUser = await Mediator.Send(getUsersMovementsByUserIdQuery);
            return Ok(usersMovementsListByUser);
        }

        [HttpGet]
        public async Task<IActionResult> GetListByUserIdAndSelectedDay([FromQuery] PageRequest pageRequest, [FromQuery] int userId,[FromQuery] int selectedDay)
        {
            GetUsersMovementsByUserIdAndSelectedDayQuery getUsersMovementsByUserIdAndSelectedDayQuery = new() { UserId = userId, PageRequest = pageRequest, SelectedDay = selectedDay };
            UsersMovementsListByUserIdAndSelectedDayModel usersMovementsListByUserIdAndSelectedDayModel = await Mediator.Send(getUsersMovementsByUserIdAndSelectedDayQuery);
            return Ok(usersMovementsListByUserIdAndSelectedDayModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUsersMovementByIdQuery getUsersMovementByIdQuery)
        {
            GetUsersMovementByIdDto getUsersMovementByIdDto = await Mediator.Send(getUsersMovementByIdQuery);
            return Ok(getUsersMovementByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsersMovementCommand createUsersMovementCommand)
        {
            CreateUsersMovementDto createUsersMovementDto = await Mediator.Send(createUsersMovementCommand);
            return Created("",createUsersMovementDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUsersMovementCommand updateUsersMovementCommand)
        {
            UpdateUsersMovementDto updateUsersMovementDto = await Mediator.Send(updateUsersMovementCommand);
            return Ok(updateUsersMovementDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUsersMovementCommand deleteUsersMovementCommand)
        {
            DeleteUsersMovementDto deleteUsersMovementDto = await Mediator.Send(deleteUsersMovementCommand);
            return Ok(deleteUsersMovementDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMobile([FromBody] DeleteUsersMovementCommand deleteUsersMovementCommand)
        {
            DeleteUsersMovementDto deleteUsersMovementDto = await Mediator.Send(deleteUsersMovementCommand);
            return Ok(deleteUsersMovementDto);
        }
    }
}

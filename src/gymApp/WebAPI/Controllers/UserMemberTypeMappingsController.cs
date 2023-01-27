using Application.Features.UserMemberTypeMappings.Commands.CreateUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Commands.DeleteUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Commands.UpdateUserMemberTypeMapping;
using Application.Features.UserMemberTypeMappings.Dtos;
using Application.Features.UserMemberTypeMappings.Models;
using Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingById;
using Application.Features.UserMemberTypeMappings.Queries.GetUserMemberTypeMappingList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserMemberTypeMappingsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetUserMemberTypeMappingListQuery getUserMemberTypeMappingListQuery = new() { PageRequest = pageRequest };
            UserMemberTypeMappingListModel userListModel = await Mediator.Send(getUserMemberTypeMappingListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserMemberTypeMappingByIdQuery getUserMemberTypeMappingByIdQuery)
        {
            GetUserMemberTypeMappingByIdDto getUserMemberTypeMappingByIdDto = await Mediator.Send(getUserMemberTypeMappingByIdQuery);
            return Ok(getUserMemberTypeMappingByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserMemberTypeMappingCommand createUserMemberTypeMappingCommand)
        {
            CreateUserMemberTypeMappingDto createUserMemberTypeMappingDto = await Mediator.Send(createUserMemberTypeMappingCommand);
            return Created("",createUserMemberTypeMappingDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserMemberTypeMappingCommand updateUserMemberTypeMappingCommand)
        {
            UpdateUserMemberTypeMappingDto updateUserMemberTypeMappingDto = await Mediator.Send(updateUserMemberTypeMappingCommand);
            return Ok(updateUserMemberTypeMappingDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserMemberTypeMappingCommand deleteUserMemberTypeMappingCommand)
        {
            DeleteUserMemberTypeMappingDto deleteUserMemberTypeMappingDto = await Mediator.Send(deleteUserMemberTypeMappingCommand);
            return Ok(deleteUserMemberTypeMappingDto);
        }
    }
}

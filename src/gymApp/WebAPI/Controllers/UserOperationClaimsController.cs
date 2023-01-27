using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetUserOperationClaimById;
using Application.Features.UserOperationClaims.Queries.GetUserOperationClaimList;
using Core.Application.Requests;
using Core.Security.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetUserOperationClaimListQuery getUserOperationClaimListQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListModel userListModel = await Mediator.Send(getUserOperationClaimListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserOperationClaimByIdQuery getUserOperationClaimByIdQuery)
        {
            GetUserOperationClaimByIdDto getUserOperationClaimByIdDto = await Mediator.Send(getUserOperationClaimByIdQuery);
            return Ok(getUserOperationClaimByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreateUserOperationClaimDto createUserOperationClaimDto = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", createUserOperationClaimDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdateUserOperationClaimDto updateUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(updateUserOperationClaimDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeleteUserOperationClaimDto deleteUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deleteUserOperationClaimDto);
        }
    }
}

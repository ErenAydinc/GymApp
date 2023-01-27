using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetOperationClaimById;
using Application.Features.OperationClaims.Queries.GetOperationClaimList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetOperationClaimListQuery getOperationClaimListQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel userListModel = await Mediator.Send(getOperationClaimListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOperationClaimByIdQuery getOperationClaimByIdQuery)
        {
            GetOperationClaimByIdDto getOperationClaimByIdDto = await Mediator.Send(getOperationClaimByIdQuery);
            return Ok(getOperationClaimByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createOperationClaimDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdateOperationClaimDto updateOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(updateOperationClaimDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeleteOperationClaimDto deleteOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deleteOperationClaimDto);
        }
    }
}

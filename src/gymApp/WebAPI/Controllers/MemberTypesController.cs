using Application.Features.MemberTypes.Commands.CreateMemberType;
using Application.Features.MemberTypes.Commands.DeleteMemberType;
using Application.Features.MemberTypes.Commands.UpdateMemberType;
using Application.Features.MemberTypes.Dtos;
using Application.Features.MemberTypes.Models;
using Application.Features.MemberTypes.Queries.GetMemberTypeById;
using Application.Features.MemberTypes.Queries.GetMemberTypeList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberTypesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetMemberTypeListQuery getMemberTypeListQuery = new() { PageRequest = pageRequest };
            MemberTypeListModel userListModel = await Mediator.Send(getMemberTypeListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMemberTypeByIdQuery getMemberTypeByIdQuery)
        {
            GetMemberTypeByIdDto getMemberTypeByIdDto = await Mediator.Send(getMemberTypeByIdQuery);
            return Ok(getMemberTypeByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMemberTypeCommand createMemberTypeCommand)
        {
            CreateMemberTypeDto createMemberTypeDto = await Mediator.Send(createMemberTypeCommand);
            return Created("",createMemberTypeDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMemberTypeCommand updateMemberTypeCommand)
        {
            UpdateMemberTypeDto updateMemberTypeDto = await Mediator.Send(updateMemberTypeCommand);
            return Ok(updateMemberTypeDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMemberTypeCommand deleteMemberTypeCommand)
        {
            DeleteMemberTypeDto deleteMemberTypeDto = await Mediator.Send(deleteMemberTypeCommand);
            return Ok(deleteMemberTypeDto);
        }
    }
}

using Application.Features.Auths.Dtos;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.GetUserList;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {

            var user = _httpContextAccessor.HttpContext.User.GetUserId();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetUserListQuery getUserListQuery = new() { PageRequest = pageRequest };
            UserListModel userListModel = await Mediator.Send(getUserListQuery);
            return Ok(userListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserByIdQuery getUserByIdQuery)
        {
            GetUserByIdDto getUserByIdDto = await Mediator.Send(getUserByIdQuery);
            return Ok(getUserByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            CreateUserCommand createUserCommand = new()
            {
                CreateUserDto = createUserDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(createUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserDto updateUserDto = await Mediator.Send(updateUserCommand);
            return Ok(updateUserDto);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}

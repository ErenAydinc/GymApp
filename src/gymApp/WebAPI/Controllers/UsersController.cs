using Application.Features.Auths.Dtos;
using Application.Features.DeleteStudents.Queries.GetDeleteStudentList;
using Application.Features.PersonalTrainers.Queries.GetPersonalTrainerList;
using Application.Features.Students.Queries.GetStudentList;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetUserByCustomerList;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Queries.GetUserList;
using Core.Application.Requests;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetPersonalTrainerList([FromQuery] PageRequest pageRequest, [FromQuery] string? searchFirstName, [FromQuery] string? searchLastName)
        {
            GetPersonalTrainerListQuery getPersonalTrainerListQuery = new() { PageRequest = pageRequest ,SearchFirstName=searchFirstName,SearchLastName=searchLastName};
            PersonalTrainerListModel personalTrainerListModel = await Mediator.Send(getPersonalTrainerListQuery);
            return Ok(personalTrainerListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList([FromQuery] PageRequest pageRequest, [FromQuery] string? searchFirstName, [FromQuery] string? searchLastName, [FromQuery] bool status)
        {
            GetStudentListQuery getStudentListQuery = new() { PageRequest = pageRequest,SearchFirstName= searchFirstName ,SearchLastName=searchLastName,Status=status};
            StudentListModel studentListModel = await Mediator.Send(getStudentListQuery);
            return Ok(studentListModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetDeleteStudentList([FromQuery] PageRequest pageRequest, [FromQuery] string? searchFirstName)
        {
            GetDeleteStudentListQuery getDeleteStudentListQuery = new() { PageRequest = pageRequest ,SearchFirstName=searchFirstName};
            DeleteStudentListModel deleteStudentListModel = await Mediator.Send(getDeleteStudentListQuery);
            return Ok(deleteStudentListModel);
        }


        /// <summary>
        /// Giren adminin customerına bağlı user listeleme
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetUserListByCustomer([FromQuery] PageRequest pageRequest)
        {
            GetUserByCustomerListQuery getUserByCustomerListQuery = new() { PageRequest = pageRequest };
            UserByCustomerListModel userByCustomerListModel = await Mediator.Send(getUserByCustomerListQuery);
            return Ok(userByCustomerListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserByIdQuery getUserByIdQuery)
        {
            GetUserByIdDto getUserByIdDto = await Mediator.Send(getUserByIdQuery);
            return Ok(getUserByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserForRegisterDto userForRegisterDto)
        {
            CreateUserCommand registerCommand = new()
            {
                 UserForRegisterDto= userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            return Created("", registerCommand);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserDto updateUserDto = await Mediator.Send(updateUserCommand);
            return Ok(updateUserDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
        {
            DeleteUserDto deleteUserDto= await Mediator.Send(deleteUserCommand);
            return Ok(deleteUserDto);
        }

        //private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        //{
        //    CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
        //    Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        //}
    }
}

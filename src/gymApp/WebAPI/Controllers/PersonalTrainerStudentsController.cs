using Application.Features.PersonalTrainerStudents.Commands.CreatePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Commands.DeletePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Commands.UpdatePersonalTrainerStudent;
using Application.Features.PersonalTrainerStudents.Dtos;
using Application.Features.PersonalTrainerStudents.Models;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentById;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentByPersonalTrainerId;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentByStudentId;
using Application.Features.PersonalTrainerStudents.Queries.GetPersonalTrainerStudentList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalTrainerStudentsController : BaseController
    {
        /// <summary>
        /// Personal trainerin öğrenci sayısını gösterir
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetPersonalTrainerStudentListQuery getPersonalTrainerStudentListQuery = new() { PageRequest = pageRequest };
            PersonalTrainerStudentListModel movementListModel = await Mediator.Send(getPersonalTrainerStudentListQuery);
            return Ok(movementListModel);
        }

        /// <summary>
        /// Personal trainere ait öğrencinin bilgileri
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <param name="personalTrainerId"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetListByPersonalTrainerId([FromQuery] PageRequest pageRequest, [FromQuery] int personalTrainerId)
        {
            GetPersonalTrainerStudentListByPersonalTrainerIdQuery getPersonalTrainerStudentListByPersonalTrainerIdQuery = new() {PersonalTrainerId=personalTrainerId, PageRequest = pageRequest };
            PersonalTrainerStudentListByPersonalTrainerIdModel personalTrainerStudentListByPersonalTrainerIdModel = await Mediator.Send(getPersonalTrainerStudentListByPersonalTrainerIdQuery);
            return Ok(personalTrainerStudentListByPersonalTrainerIdModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetPersonalTrainerStudentByIdQuery getPersonalTrainerStudentByIdQuery)
        {
            GetPersonalTrainerStudentByIdDto getPersonalTrainerStudentByIdDto = await Mediator.Send(getPersonalTrainerStudentByIdQuery);
            return Ok(getPersonalTrainerStudentByIdDto);
        }

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetByStudentId([FromRoute] GetPersonalTrainerStudentByStudentIdQuery getPersonalTrainerStudentByStudentIdQuery)
        {
            GetPersonalTrainerStudentByStudentIdDto getPersonalTrainerStudentByStudentIdDto = await Mediator.Send(getPersonalTrainerStudentByStudentIdQuery);
            return Ok(getPersonalTrainerStudentByStudentIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonalTrainerStudentCommand createPersonalTrainerStudentCommand)
        {
            CreatePersonalTrainerStudentDto createPersonalTrainerStudentDto = await Mediator.Send(createPersonalTrainerStudentCommand);
            return Created("",createPersonalTrainerStudentDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonalTrainerStudentCommand updatePersonalTrainerStudentCommand)
        {
            UpdatePersonalTrainerStudentDto updatePersonalTrainerStudentDto = await Mediator.Send(updatePersonalTrainerStudentCommand);
            return Ok(updatePersonalTrainerStudentDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePersonalTrainerStudentCommand deletePersonalTrainerStudentCommand)
        {
            DeletePersonalTrainerStudentDto deletePersonalTrainerStudentDto = await Mediator.Send(deletePersonalTrainerStudentCommand);
            return Ok(deletePersonalTrainerStudentDto);
        }
    }
}

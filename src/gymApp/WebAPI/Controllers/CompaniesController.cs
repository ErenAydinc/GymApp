using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Models;
using Application.Features.Companies.Queries.GetCompanyById;
using Application.Features.Companies.Queries.GetCompanyList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetCompanyListQuery getCompanyListQuery = new() { PageRequest = pageRequest };
            CompanyListModel CompanyListModel = await Mediator.Send(getCompanyListQuery);
            return Ok(CompanyListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCompanyByIdQuery getCompanyByIdQuery)
        {
            GetCompanyByIdDto getCompanyByIdDto = await Mediator.Send(getCompanyByIdQuery);
            return Ok(getCompanyByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            CreateCompanyDto createCompanyDto = await Mediator.Send(createCompanyCommand);
            return Created("",createCompanyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            UpdateCompanyDto updateCompanyDto = await Mediator.Send(updateCompanyCommand);
            return Ok(updateCompanyDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCompanyCommand deleteCompanyCommand)
        {
            DeleteCompanyDto deleteCompanyDto = await Mediator.Send(deleteCompanyCommand);
            return Ok(deleteCompanyDto);
        }
    }
}

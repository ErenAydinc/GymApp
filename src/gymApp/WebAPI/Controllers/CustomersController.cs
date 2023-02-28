using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Models;
using Application.Features.Customers.Queries.GetCustomerById;
using Application.Features.Customers.Queries.GetCustomerList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetCustomerListQuery getCustomerListQuery = new() { PageRequest = pageRequest };
            CustomerListModel CustomerListModel = await Mediator.Send(getCustomerListQuery);
            return Ok(CustomerListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCustomerByIdQuery getCustomerByIdQuery)
        {
            GetCustomerByIdDto getCustomerByIdDto = await Mediator.Send(getCustomerByIdQuery);
            return Ok(getCustomerByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CreateCustomerDto createCustomerDto = await Mediator.Send(createCustomerCommand);
            return Created("",createCustomerDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            UpdateCustomerDto updateCustomerDto = await Mediator.Send(updateCustomerCommand);
            return Ok(updateCustomerDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomerCommand)
        {
            DeleteCustomerDto deleteCustomerDto = await Mediator.Send(deleteCustomerCommand);
            return Ok(deleteCustomerDto);
        }
    }
}

using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Features.Categories.Queries.GetCategoryList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetCategoryListQuery getCategoryListQuery = new() { PageRequest = pageRequest };
            CategoryListModel categoryListModel = await Mediator.Send(getCategoryListQuery);
            return Ok(categoryListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryByIdQuery getCategoryByIdQuery)
        {
            GetCategoryByIdDto getCategoryByIdDto = await Mediator.Send(getCategoryByIdQuery);
            return Ok(getCategoryByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDto createCategoryDto = await Mediator.Send(createCategoryCommand);
            return Created("",createCategoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdateCategoryDto updateCategoryDto = await Mediator.Send(updateCategoryCommand);
            return Ok(updateCategoryDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeleteCategoryDto deleteCategoryDto = await Mediator.Send(deleteCategoryCommand);
            return Ok(deleteCategoryDto);
        }
    }
}

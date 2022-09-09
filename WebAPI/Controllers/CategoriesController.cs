using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.SoftDeleteCategory;
using Application.Features.Categories.Commands.UndoDeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategories;
using Application.Features.Categories.Queries.GetNonDeletedListCategories;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryDto result = await Mediator.Send(createCategoryCommand);

        return Created("", result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
    {
        DeletedCategoryDto result = await Mediator.Send(deleteCategoryCommand);

        return Created("", result);
    }
    
    [HttpPost("SoftDelete")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteCategoryCommand softDeleteCategoryCommand)
    {
        SoftDeletedCategoryDto result = await Mediator.Send(softDeleteCategoryCommand);

        return Created("", result);
    }
    
    [HttpPost("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteCategoryCommand undoDeleteCategoryCommand)
    {
        UndoDeletedCategoryDto result = await Mediator.Send(undoDeleteCategoryCommand);

        return Created("", result);
    }
    
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryDto result = await Mediator.Send(updateCategoryCommand);

        return Created("", result);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
        CategoryListModel result = await Mediator.Send(getListCategoryQuery);

        return Ok(result);
    }
    
    [HttpGet("GetNonDeletedList")]
    public async Task<IActionResult> GetNonDeletedList([FromQuery] PageRequest pageRequest)
    {
        GetNonDeletedListCategoryQuery getNonDeletedListCategoryQuery = new() { PageRequest = pageRequest };
        CategoryNonDeletedListModel result = await Mediator.Send(getNonDeletedListCategoryQuery);

        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdCategoryQuery getByIdCategoryQuery)
    {
        CategoryGetByIdDto categoryGetByIdDto = await Mediator.Send(getByIdCategoryQuery);
        return Ok(categoryGetByIdDto);
    }
}
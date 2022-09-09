using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.SoftDeleteBrand;
using Application.Features.Brands.Commands.UndoDeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrands;
using Application.Features.Brands.Queries.GetNonDeletedListBrands;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandDto result = await Mediator.Send(createBrandCommand);

        return Created("", result);
    }
    
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
    {
        DeletedBrandDto result = await Mediator.Send(deleteBrandCommand);

        return Created("", result);
    }
    
    [HttpPost("SoftDelete")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteBrandCommand softDeleteBrandCommand)
    {
        SoftDeletedBrandDto result = await Mediator.Send(softDeleteBrandCommand);

        return Created("", result);
    }
    
    [HttpPost("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteBrandCommand undoDeleteBrandCommand)
    {
        UndoDeletedBrandDto result = await Mediator.Send(undoDeleteBrandCommand);

        return Created("", result);
    }
    
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandDto result = await Mediator.Send(updateBrandCommand);

        return Created("", result);
    }
    
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        BrandListModel result = await Mediator.Send(getListBrandQuery);

        return Ok(result);
    }
    
    [HttpGet("GetNonDeletedList")]
    public async Task<IActionResult> GetNonDeletedList([FromQuery] PageRequest pageRequest)
    {
        GetNonDeletedListBrandQuery getNonDeletedListBrandQuery = new() { PageRequest = pageRequest };
        BrandNonDeletedListModel result = await Mediator.Send(getNonDeletedListBrandQuery);

        return Ok(result);
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdBrandQuery getByIdBrandQuery)
    {
        BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);
        return Ok(brandGetByIdDto);
    }
}
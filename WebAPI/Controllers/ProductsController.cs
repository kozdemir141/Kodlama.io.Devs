using Application.Features.Categories.Dtos;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.SoftDeleteProduct;
using Application.Features.Products.Commands.UndoDeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries.GetByIdProduct;
using Application.Features.Products.Queries.GetListProductByDynamic;
using Application.Features.Products.Queries.GetListProducts;
using Application.Features.Products.Queries.GetListProductsByBrand;
using Application.Features.Products.Queries.GetListProductsByCategory;
using Application.Features.Products.Queries.GetNonDeletedProducts;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductDto result = await Mediator.Send(createProductCommand);

        return Created("", result);
    }
    
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
    {
        DeletedProductDto result = await Mediator.Send(deleteProductCommand);

        return Created("", result);
    }
    
    [HttpPost("SoftDelete")]
    public async Task<IActionResult> SoftDelete([FromBody] SoftDeleteProductCommand softDeleteProductCommand)
    {
        SoftDeletedProductDto result = await Mediator.Send(softDeleteProductCommand);

        return Created("", result);
    }
    
    [HttpPost("UndoDelete")]
    public async Task<IActionResult> UndoDelete([FromBody] UndoDeleteProductCommand undoDeleteProductCommand)
    {
        UndoDeletedProductDto result = await Mediator.Send(undoDeleteProductCommand);

        return Created("", result);
    }
    
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        UpdatedProductDto result = await Mediator.Send(updateProductCommand);

        return Created("", result);
    }
    
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        ProductListModel result = await Mediator.Send(getListProductQuery);

        return Ok(result);
    }
    
    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListProductByDynamicQuery getListProductByDynamicQuery = new GetListProductByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        ProductListModel result = await Mediator.Send(getListProductByDynamicQuery);
        return Ok(result);

    }
    
    [HttpGet("GetNonDeletedList")]
    public async Task<IActionResult> GetNonDeletedList([FromQuery] PageRequest pageRequest)
    {
        GetNonDeletedListProductQuery getNonDeletedListProductQuery = new() { PageRequest = pageRequest };
        ProductNonDeletedListModel result = await Mediator.Send(getNonDeletedListProductQuery);

        return Ok(result);
    }
    
    [HttpGet("GetListByCategory")]
    public async Task<IActionResult> GetListByCategory([FromQuery] PageRequest pageRequest,int categoryId)
    {
        GetListProductsByCategoryQuery getListProductsByCategoryQuery = new() { PageRequest = pageRequest, CategoryId = categoryId};
        ProductListByCategoryModel result = await Mediator.Send(getListProductsByCategoryQuery);

        return Ok(result);
    }
    
    [HttpGet("GetListByBrand")]
    public async Task<IActionResult> GetListByBrand([FromQuery] PageRequest pageRequest,int brandId)
    {
        GetListProductsByBrandQuery getListProductsByBrandQuery = new() { PageRequest = pageRequest, BrandId = brandId};
        ProductListByBrandModel result = await Mediator.Send(getListProductsByBrandQuery);

        return Ok(result);
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdProductQuery getByIdProductQuery)
    {
        ProductGetByIdDto productGetByIdDto = await Mediator.Send(getByIdProductQuery);
        return Ok(productGetByIdDto);
    }
}
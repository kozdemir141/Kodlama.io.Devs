using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaims;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);

        return Ok(result);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);

        return Created("", result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);

        return Created("", result);
    }
    
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);

        return Created("", result);
    }
    
}
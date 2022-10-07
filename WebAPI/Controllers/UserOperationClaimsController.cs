using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetListUserOperationClaims;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);

        return Ok(result);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);

        return Created("", result);
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);

        return Created("", result);
    }
    
    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        UpdatedUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);

        return Created("", result);
    }
}
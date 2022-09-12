using Application.Features.Brands.Dtos;
using Application.Features.UserOfficialWebSites.Commands.CreateUserOfficialWebSite;
using Application.Features.UserOfficialWebSites.Commands.DeleteUserOfficialWebSite;
using Application.Features.UserOfficialWebSites.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOfficialWebSitesController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateUserOfficialWebSiteCommand createUserOfficialWebSiteCommand)
    {
        CreatedUserOfficialWebSiteDto result = await Mediator.Send(createUserOfficialWebSiteCommand);

        return Created("", result);
    }
    
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOfficialWebSiteCommand deleteUserOfficialWebSiteCommand)
    {
        DeletedUserOfficialWebSiteDto result = await Mediator.Send(deleteUserOfficialWebSiteCommand);

        return Created("", result);
    }
}
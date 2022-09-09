using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
    {
        var result = await Mediator.Send(registerUserCommand);

        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
    {
        var result = await Mediator.Send(loginUserCommand);

        return Ok(result);
    }
}
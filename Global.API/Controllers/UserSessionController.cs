using Global.Application.Commands.Inputs.User;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Global.Application.Commands.Handlers.Login;
using Global.Application.Commands.Handlers.Token;
using Microsoft.AspNetCore.Identity.Data;

namespace Global_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSessionController : ControllerBase
{
    private readonly IMediator _mediator; 

    public UserSessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region POST
    [HttpPost("register")]
    public async Task<IActionResult> CreateUserSessionAsync([FromBody] CreateUserSessionCommandInput command)
    {
        if (command == null)
            return BadRequest("Invalid data");

        int userId = await _mediator.Send(command);

        return Ok(new { userId });
    }
    #endregion
}
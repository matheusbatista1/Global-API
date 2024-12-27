using Global.Application.Commands.Handlers.Login;
using Global.Application.Commands.Handlers.Token;
using Global.Application.Commands.Inputs.Login;
using Microsoft.AspNetCore.Mvc;

namespace Global_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly LoginCommandHandler _loginCommandHandler;
    private readonly TokenCommandHandler _tokenCommandHandler;

    public TokenController(LoginCommandHandler loginCommandHandler, TokenCommandHandler tokenCommandHandler)
    {
        _loginCommandHandler = loginCommandHandler;
        _tokenCommandHandler = tokenCommandHandler;
    }

    #region POST
    [HttpPost]
    public async Task<IActionResult> GenerateToken([FromBody] LoginCommandInput loginCommandInput)
    {
        var user = await _loginCommandHandler.AuthenticateUser(loginCommandInput);
        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = _tokenCommandHandler.GenerateJwtToken(user.Email);
        return Ok(new { token });
    }
    #endregion
}
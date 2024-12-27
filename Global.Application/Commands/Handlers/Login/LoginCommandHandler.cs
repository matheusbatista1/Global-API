using Global.Application.Commands.Inputs.Login;
using Global.Domain.Entities;
using Global.Domain.Interfaces;

namespace Global.Application.Commands.Handlers.Login;

public class LoginCommandHandler
{
    private readonly IUserSessionRepository _userRepository;

    public LoginCommandHandler(IUserSessionRepository userRepository) 
    {  
        _userRepository = userRepository; 
    }

    public async Task<UserSession?> AuthenticateUser(LoginCommandInput command)
    {
        var user = await _userRepository.GetUserByEmailAsync(command.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash)) 
        {
            return null;
        }

        return user;
    }
}
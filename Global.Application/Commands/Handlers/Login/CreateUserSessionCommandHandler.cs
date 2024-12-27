using Global.Application.Commands.Inputs.User;
using Global.Domain.Entities;
using Global.Domain.Interfaces;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Global.Application.Commands.Handlers.Login;

public class CreateUserSessionCommandHandler : IRequestHandler<CreateUserSessionCommandInput, int>
{
    private readonly IUserSessionRepository _userSessionRepository;

    public CreateUserSessionCommandHandler(IUserSessionRepository userRepository)
    {
        _userSessionRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserSessionCommandInput command, CancellationToken cancellationToken)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

        var user = new UserSession
        {
            Name = command.Name,
            Email = command.Email,
            PasswordHash = passwordHash
        };

        var userId = await _userSessionRepository.CreateUserAsync(user);
        return userId;
    }
}
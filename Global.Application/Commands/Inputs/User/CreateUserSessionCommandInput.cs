using MediatR;

namespace Global.Application.Commands.Inputs.User;

public class CreateUserSessionCommandInput : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
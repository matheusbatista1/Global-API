using Global.Domain.Entities;

namespace Global.Domain.Interfaces;

public interface IUserSessionRepository
{
    Task<UserSession> GetUserByEmailAsync(string email);
    Task<int> CreateUserAsync(UserSession entity);
}
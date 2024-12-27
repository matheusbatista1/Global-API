using Dapper;
using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Application.Constants.User;
using System.Data;

namespace Global.Application.Repositories;

public class UserSessionRepository : IUserSessionRepository
{
    private readonly IDbConnection _dbConnection;

    public UserSessionRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    #region GET
    public async Task<UserSession> GetUserByEmailAsync(string email)
    {
        var sql = UserSessionRepositoryConstant.GET_USER_BY_EMAIL;
        var user = await _dbConnection.QueryFirstOrDefaultAsync<UserSession>(sql, new { Email = email });
        return user;
    }
    #endregion

    #region INSERT
    public async Task<int> CreateUserAsync(UserSession user)
    {
        var sql = UserSessionRepositoryConstant.INSERT_USER;
        var userId = await _dbConnection.QuerySingleAsync<int>(sql, new { user.Name, user.Email, user.PasswordHash });
        return userId;
    }
    #endregion
}
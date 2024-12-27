namespace Global.Application.Constants.User;

public class UserSessionRepositoryConstant
{
    public const string GET_USER_BY_EMAIL = @"
                                              SELECT Id, Name, Email, PasswordHash
                                              FROM UserSession
                                              WHERE Email = @Email";

    public const string INSERT_USER = @"
                                        INSERT INTO UserSession (Name, Email, PasswordHash)
                                        VALUES (@Name, @Email, @PasswordHash);
                                        SELECT SCOPE_IDENTITY()";
}
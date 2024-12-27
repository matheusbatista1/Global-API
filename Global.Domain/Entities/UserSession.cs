namespace Global.Domain.Entities;

public class UserSession
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
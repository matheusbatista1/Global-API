namespace Global.Application.Constants.Contact;

public static class ContactRepositoryConstant
{
    public const string GET_CONTACT_BY_ID = @"SELECT 
                                                ct.ContactID AS Id,
                                                ct.Name AS Name
                                              FROM Contact ct 
                                              WHERE ContactID = @Id";

    public const string CREATE_CONTACT = @"INSERT INTO Contact (Nome) VALUES (@Name)";

    public const string UPDATE_CONTACT = @"UPDATE Contact SET Nome = @Name WHERE ContactID = @Id";
}
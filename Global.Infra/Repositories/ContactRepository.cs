using Dapper;
using Global.Domain.Entities;
using Global.Application.Constants.Contact;
using Global.Application.Data;
using Global.Domain.Interfaces;

namespace Global.Application.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly GlobalDbContext _context;

    public ContactRepository(GlobalDbContext context)
    {
        _context = context;
    }
    #region SELECT
    public async Task<Contact> GetByIdAsync(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = ContactRepositoryConstant.GET_CONTACT_BY_ID;
            var contact = await connection.QueryFirstOrDefaultAsync<Contact>(sql, new { id });
            return contact;
        }
    }
    #endregion

    #region INSERT
    public async Task<bool> CreateAsync(Contact contact)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = ContactRepositoryConstant.CREATE_CONTACT;
            await connection.ExecuteAsync(sql, new { contact.Name });
            return true;
        }
    }
    #endregion

    #region UPDATE
    public async Task<bool> UpdateAsync(Contact contact)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = ContactRepositoryConstant.UPDATE_CONTACT;
            await connection.ExecuteAsync(sql, new { contact.Id, contact.Name });
            return true;
        }
    }
    #endregion

    #region DELETE
    #endregion

}